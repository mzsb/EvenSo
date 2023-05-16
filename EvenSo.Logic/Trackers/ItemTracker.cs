#region Usings

using EvenSo.Caches;
using EvenSo.Logic.Structures.PropertyTree;
using EvenSo.PropertyTrees;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Xml;

#endregion

namespace EvenSo.Trackers
{
    public sealed class ItemTracker
    {
        private readonly ItemTrackerOptions _options = new();

        public ItemTracker WithOptions(Action<ItemTrackerOptions>? options = null)
        {
            options?.Invoke(_options);

            return this;
        }


        private ConditionalWeakTable<object, IPropertyTree> Items { get; } = new();

        public void AddOrUpdate(object item)
        {
            if (item is null) throw new Exception();

            Items.AddOrUpdate(item, _options.ToTree(item));
        }

        public void Check(object item)
        {
            if (item is null) throw new Exception();

            Items.TryGetValue(item, out var propertyTree);

            var i = propertyTree?.ChangedNodes.ToArray();



            _ = 0;
        }
    }

    public sealed class ItemTrackerOptions
    {
        public Func<object, IPropertyTree> ToTree { get; set; } = item => new PropertyTree(item);
    }
}
//    public static class ItemChanges
//    {
//        public static ItemChange Track(this object item) => new (item);
//    }

//    public interface ISegment
//    {
//        public string Path { get; init; }

//        public object? Value { get; init; }
//    }

//    public class Segment : ISegment
//    {
//        public string Path { get; init; }

//        public object? Value { get; init; }
//    }

//    public static class SegmentFactory
//    {
//        public static ISegment? CreateSegment(Node node)
//        {
//            return node switch
//            {
//                { Value: null } => CreateNull(node),
//                { Type: NodeType.Primitive } => CreatePrimitive(node),
//                _ => throw new NodeException($"{node.Type} node type not exists.", node)
//            };
//        }

//        private static ISegment? CreateNull(Node node)
//        {
//            if (node.ActualValue != null)
//            {
//                return new Segment()
//                {
//                    //Path = string.Join("/", node.GetPath()),
//                    Value = node.ActualValue
//                };
//            }

//            return null;
//        }

//        private static ISegment? CreatePrimitive(Node node)
//        {
//            if (node.Value != node.ActualValue)
//            {
//                return new Segment()
//                {
//                    //Path = string.Join("/", node.GetPath()),
//                    Value = node.ActualValue
//                };
//            }

//            return null;
//        }

//        //private static IEnumerable<string> GetPath(this INode node) =>
//        //    node.GetBranch().Reverse().Select(node =>
//        //        node.Property is not null ? node.Property.Name : string.Empty);
//    }


//    public class ItemChange
//    {
//        private readonly ImmutableArray<INode> _nodes;

//        public ItemChange(object item)
//        {
//            Item = item;
//            //_nodes = item.GetNodes();
//        }

//        public object Item { get; }

//        public bool GetChanges(out ImmutableArray<ISegment?> changes)
//        {
//            var tmp = new List<ISegment?>();
//            if (_nodes.Length > 1)
//            {
//                foreach (var node in _nodes.Where(node =>
//                    node.Type != NodeType.Root &&
//                    node.Type != NodeType.Element))
//                {
//                    tmp.Add(SegmentFactory.CreateSegment(node));
//                };
//            }

//            if (tmp.Any())
//            {
//                changes = tmp.ToImmutableArray();
//                return true;
//            }
//            else
//            {
//                changes = new ImmutableArray<ISegment>();
//                return false;
//            }
//        }
//    }
//}
