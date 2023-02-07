#region Usings

using EvenSo.PropertyTrees;

#endregion

namespace EvenSo.Trackers
{
    public class Tracker
    {

        public Tracker(object item)
        {

            //var nodes = new PropertyTree(item).Nodes.ToArray();

            //var f = i.Trees;

            //var t = new PropertyNode(item);
            //var i = new PropertyNode(item);

            _ = 0;
        }
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
