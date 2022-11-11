using EvenSo.Logic.Attributes;
using EvenSo.Logic.Extensions;
using System.Collections;
using System.Collections.Immutable;
using System.Diagnostics;

namespace EvenSo.Logic
{
    public class UpdateTracker
    {
        private readonly Dictionary<object, UpdateHolder> _items = new();
        private readonly Dictionary<object, Thread> _workers = new();
        public void Track(object item)
        {
            var worker = new Thread(() => _items.TryAdd(item, Travel(item)));
            _workers.Add(item, worker);
            worker.Start();
        }

        public void BeforUpdate(object item)
        {
            if (_workers.TryGetValue(item, out var worker))
            {
                worker.Join();
            }

            foreach (var segment in _items[item].Segments)
            {
                Console.WriteLine($"{segment.Path} {{{segment.Value}}} | {segment.ReferenceData}");
            }
        }

        public UpdateHolder Travel(object o)
        {
            var builder = new UpdateHolder();
            var objectList = new Stack<(object, Segment)>(new[] { (o, new Segment()) });
            while (objectList.Any())
            {
                var (item, segment) = objectList.Pop();

                if (item?.IsReference() ?? false)
                {
                    segment.ReferenceData = (item?.GetId(), item?.GetPartitionKey(), string.Empty);
                }

                foreach (var property in item.GetProperties())
                {
                    var newItem = item.GetValueOf(property) ?? (property.Type.IsNotSystem() ? Activator.CreateInstance(property.Type) : null);

                    var newSegmentPath = string.Empty;
                    var listSegmentPath = string.Empty;
                    var newSegment = new Segment();

                    if (property.IsCollection)
                    {
                        var collection = (ICollection)newItem;
                        var ids = new List<object>();

                        newSegmentPath = $"/{property.Name}";
                        newSegment.Path = $"{segment.Path}{newSegmentPath}";
                        listSegmentPath = newSegment.Path;

                        if (property.CollectionType?.IsSystem() ?? true)
                        {
                            if (segment.ReferenceData is { } referenceData)
                            {
                                newSegment.ReferenceData = (referenceData.id, referenceData.partitionKey, referenceData.path + newSegmentPath);
                            }

                            newSegment.Value = newItem;
                            builder.Segments.Add(newSegment);
                            newSegment.Getter = () => item.GetValueOf(property);
                            if (!property.IsReferenced)
                            {
                                newSegment.ReferenceData = null;
                            }
                        }
                        else
                        {
                            foreach (var listItem in collection)
                            {
                                newSegmentPath = $"/{property.Name}{(listItem.GetType().IsNotSystem() ? $"/{listItem.GetId()}" : string.Empty)}";
                                newSegment.Path = $"{segment.Path}{newSegmentPath}";

                                if (segment.ReferenceData is { } referenceData)
                                {
                                    newSegment.ReferenceData = (referenceData.id, referenceData.partitionKey, referenceData.path + newSegmentPath);
                                }

                                ids.Add(listItem?.GetId()!);

                                if (listItem?.IsReference() ?? false)
                                {
                                    newSegment.ReferenceData = (listItem?.GetId(), listItem?.GetPartitionKey(), string.Empty);
                                }

                                objectList.Push((listItem!, newSegment));

                                newSegment = new Segment();
                            }

                            builder.ListSegments.Add(new ListSegment
                            {
                                Path = listSegmentPath,
                                Ids = ids.ToArray(),
                                NewItems = () => collection.Cast<object>().ToArray()
                            });
                        }
                    }
                    else
                    {
                        newSegmentPath = $"/{property.Name}";
                        newSegment.Path = $"{segment.Path}{newSegmentPath}";

                        if (segment.ReferenceData is { } referenceData)
                        {
                            newSegment.ReferenceData = (referenceData.id, referenceData.partitionKey, referenceData.path + newSegmentPath);
                        }

                        if (property.Type.IsNotSystem())
                        {
                            if (newItem?.IsReference() ?? false)
                            {
                                newSegment.ReferenceData = (newItem?.GetId(), newItem?.GetPartitionKey(), string.Empty);
                            }

                            objectList.Push((newItem!, newSegment));
                        }
                        else
                        {
                            newSegment.Value = newItem;
                            newSegment.Getter = () => item.GetValueOf(property);
                            if (!property.IsReferenced)
                            {
                                newSegment.ReferenceData = null;
                            }
                            builder.Segments.Add(newSegment);
                        }
                    }
                }

            }

            return builder;
        }

        [DebuggerDisplay("{Path}")]
        public class Node
        {
            public object? Value { get; init; }
            public Node? Parent { get; init; }
            public Node? Reference { get; set; }
            public string Path { get; set; } = string.Empty;
            public bool IsVisited { get; set; } = false;
        }

        public UpdateHolder Travel2(object item)
        {
            var builder = new UpdateHolder();
            var nodes = new List<Node>() { new Node { Value = item } };

            while (nodes.Any(node => !node.IsVisited))
            {
                var node = nodes.First(node => !node.IsVisited);

                if(node.Value is { } nodeValue)
                {
                    if (nodeValue.IsNotSystem())
                    {
                        foreach (var property in nodeValue.GetProperties())
                        {
                            nodes.Add(new Node
                            {
                                Value = nodeValue.GetValueOf(property),
                                Parent = node,
                                Reference = nodeValue.IsReference() ? node : node.Reference,
                                Path = $"{node.Path}/{property.Name}"
                            });
                        }
                    }
                    else
                    {
                        if (nodeValue.IsCollection() && nodeValue as IEnumerable is { } listNode)
                        {
                            if (listNode!.GetCollectionType()!.IsNotSystem())
                            {
                                foreach (var element in listNode)
                                {
                                    if (element.IsNotSystem())
                                    {
                                        var elementNode = new Node
                                        {
                                            Value = element,
                                            Parent = node,
                                            Reference = element.IsReference() ? node : node.Reference,
                                            Path = $"{node.Path}/{element.GetId()}"
                                        };
                                        elementNode.Reference = element.IsReference() ? elementNode : node.Reference;
                                        nodes.Add(elementNode);
                                    }
                                }
                            }
                            else
                            {
                                nodes.Add(new Node
                                {
                                    Value = listNode,
                                    Parent = node,
                                    Reference = node.Reference,
                                    Path = $"{node.Path}"
                                });
                            }
                        }
                    }
                }

                node.IsVisited = true;
            }

            return builder;
        }

        public void DetectChanges(object item)
        {
            BeforUpdate(item);

            foreach (var listSegment in _items[item].ListSegments)
            {
                var ids = listSegment.Ids;
                var newItems  = listSegment.NewItems();

                var removedPaths = ids.Where(id => !newItems.Select(item => item.GetId()).Contains(id)).Select(id => $"{listSegment.Path}/{id}");
                
                var newSegments = _items[item].Segments
                    .Where(s => !removedPaths.Any(rp => s.Path.StartsWith(rp)) && 
                        (!s.Value?.Equals(s.Getter()) ?? s.Getter() is not null)).ToList();

                foreach (var newItem in newItems.Where(item => !ids.Contains(item.GetId())))
                {
                    var t = Travel(newItem);
                    foreach (var segment in t.Segments)
                    {
                        segment.Path = $"{listSegment.Path}/{newItem.GetId()}{segment.Path}";
                        newSegments.Add(segment);
                    }
                }

                _ = 0;
            }
        }
    }

    public class UpdateHolder
    {
        public List<ListSegment> ListSegments { get; set; } = new();
        public List<Segment> Segments { get; set; } = new();
    }

    [DebuggerDisplay("{Path}")]
    public class Segment
    {
        public object? Value { get; set; }
        public Func<object?> Getter { get; set; } = () => new (); 
        public string Path { get; set; } = string.Empty;
        public (object? id, object? partitionKey, string path)? ReferenceData { get; set; }
    }

    public class ListSegment
    {
        public string Path { get; set; } = string.Empty;
        public object[] Ids { get; set; } = Array.Empty<object>();
        public Func<object[]> NewItems { get; set; } = () => Array.Empty<object>();
    }
}
