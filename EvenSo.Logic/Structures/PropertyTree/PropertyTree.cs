#region Usings

using EvenSo.Caches;
using System.Diagnostics;

#endregion

namespace EvenSo.PropertyTrees
{
    //#if DEBUG
    //[DebuggerDisplay("{Root}")]
    //#endif
    //public class PropertyTree
    //{
    //    private readonly object _rootValue;

    //    public PropertyTree(object rootValue) => _rootValue = rootValue;

    //    private PropertyNode? _root;

    //    public PropertyNode Root => _root ??= Create().Root;

    //    public PropertyTree Create()
    //    {
    //        _root = new PropertyNode { Value = _rootValue };

    //        var nodes = new Stack<PropertyNode>(new[] { _root });
    //        while (nodes.TryPop(out var node))
    //        {
    //            node.Children = node.Value is { } value ? (node.Type switch
    //            {
    //                Internal =>
    //                    node.Children = value
    //                        .GetCachedProperties()
    //                        .Select(property =>
    //                        {
    //                            var child = new PropertyNode
    //                            {
    //                                Property = property,
    //                                Value = value.GetValueOf(property),
    //                                Parent = node
    //                            };
    //                            nodes.Push(child);
    //                            return child;
    //                        }),

    //                Internal_Collection =>
    //                    node.Children = ((IEnumerable<object?>)value)
    //                        .Select(element =>
    //                        {
    //                            var child = new PropertyNode
    //                            {
    //                                Value = element,
    //                                Parent = node
    //                            };
    //                            nodes.Push(child);
    //                            return child;
    //                        }),

    //                _ => Enumerable.Empty<PropertyNode>()

    //            }).ToArray() : Enumerable.Empty<PropertyNode>();
    //        }

    //        return this;
    //    }

    //    public IEnumerable<PropertyNode> Nodes
    //    {
    //        get
    //        {
    //            var nodes = new Stack<PropertyNode>(new[] { Root });
    //            while (nodes.TryPop(out var node))
    //            {
    //                yield return node;
    //                foreach (var child in node.Children)
    //                {
    //                    nodes.Push(child);
    //                }
    //            }
    //        }
    //    }
    //}

    public class PropertyTree2
    {
        private readonly object _rootValue;

        public PropertyTree2(object rootValue) => _rootValue = rootValue;

        private PropertyNode2? _root;

        public PropertyNode2 Root => _root ??= Create().Root;

        public PropertyTree2 Create()
        {
            _root = new PropertyNode2(() => _rootValue, new[] { 'r', 'o', 'o', 't' });
            return this;
        }

        public IEnumerable<PropertyNode2> Nodes
        {
            get
            {
                var nodes = new Stack<PropertyNode2>(new[] { Root });
                while (nodes.TryPop(out var node))
                {
                    yield return node;
                    foreach (var child in node.Children)
                    {
                        nodes.Push(child);
                    }
                }
            }
        }
    }

    public class PropertyTree3
    {
        private readonly object _rootValue;

        public PropertyTree3(object rootValue) => _rootValue = rootValue;

        private PropertyNode3? _root;

        public PropertyNode3 Root => _root ??= Create().Root;

        public PropertyTree3 Create()
        {
            _root = new PropertyNode3(() => _rootValue, new[]{ 'r', 'o', 'o', 't'});
            return this;
        }

        public IEnumerable<PropertyNode3> Nodes
        {
            get
            {
                var nodes = new Stack<PropertyNode3>(new[] { Root });
                while (nodes.TryPop(out var node))
                {
                    yield return node;
                    foreach (var child in node.Children)
                    {
                        nodes.Push(child);
                    }
                }
            }
        }
    }
}
