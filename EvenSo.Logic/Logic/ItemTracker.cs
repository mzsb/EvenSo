#region Usings

using EvenSo.Logic.Extensions;
using EvenSo.Nodes;
using System.Collections.Immutable;
using EvenSo.Logic.Exceptions;
using System.Collections.Generic;

#endregion

namespace EvenSo.Logic
{
    public static class ItemChanges
    {
        public static ItemChange Track(this object item) => new (item);
    }

    public interface ISegment
    {
        public string Path { get; init; }

        public object? Value { get; init; }
    }

    public class Segment : ISegment
    {
        public string Path { get; init; }

        public object? Value { get; init; }
    }

    public static class SegmentFactory
    {
        public static ISegment? CreateSegment(INode node)
        {
            return node switch
            {
                { Value: null } => CreateNull(node),
                { Type: NodeType.Primitive } => CreatePrimitive(node),
                _ => throw new NodeException($"{node.Type} node type not exists.", node)
            };
        }

        private static ISegment? CreateNull(INode node)
        {
            if (node.ActualValue != null)
            {
                return new Segment()
                {
                    Path = string.Join("/", node.GetPath()),
                    Value = node.ActualValue
                };
            }

            return null;
        }

        private static ISegment? CreatePrimitive(INode node)
        {
            if (node.Value != node.ActualValue)
            {
                return new Segment()
                {
                    Path = string.Join("/", node.GetPath()),
                    Value = node.ActualValue
                };
            }

            return null;
        }

        private static IEnumerable<string> GetPath(this INode node) =>
            node.GetBranch().Reverse().Select(node =>
                node.Property is not null ? node.Property.Name : string.Empty);
    }


    public class ItemChange
    {
        private readonly ImmutableArray<INode> _nodes;

        public ItemChange(object item)
        {
            Item = item;
            _nodes = item.GetNodes().ToImmutableArray();
        }

        public object Item { get; }

        public bool GetChanges(out ImmutableArray<ISegment?> changes)
        {
            var tmp = new List<ISegment?>();
            if (_nodes.Length > 1)
            {
                foreach (var node in _nodes.Where(node =>
                    node.Type != NodeType.Root &&
                    node.Type != NodeType.Element))
                {
                    tmp.Add(SegmentFactory.CreateSegment(node));
                };
            }

            if (tmp.Any())
            {
                changes = tmp.ToImmutableArray();
                return true;
            }
            else
            {
                changes = new ImmutableArray<ISegment>();
                return false;
            }
        }
    }
}
