#region Usings

using EvenSo.Keys;
using EvenSo.Logic.Extensions;
using System.Collections;
using System.Collections.Immutable;
using System.Diagnostics;

#endregion

namespace EvenSo.Nodes
{
    public static class Nodes
    {
        public static IEnumerable<INode> GetNodes(this object item)
        {
            var nodes = new Stack<Node>(new[] { new Node(value: item) });
            while (nodes.TryPop(out var node))
            {
                yield return node;

                if (node.Value is { } value)
                {
                    if (value.IsNotSystem())
                    {
                        foreach (var property in value.GetProperties())
                        {
                            nodes.Push(new(
                                value: value.GetValueOf(property),
                                parent: node,
                                property: property
                            ));
                        }
                    }
                    else
                    {
                        if (node.Type == NodeType.Enumerable &&
                            node.GetGenericType() is { } genericType &&
                            genericType.HasKeys(KeyType.Id))
                        {
                            foreach (var element in (IEnumerable)value)
                            {
                                nodes.Push(new(
                                    value: element,
                                    parent: node
                                ));
                            }
                        }
                    }
                }
            }
        }

        public static NodeType GetType(this INode node) => (node switch
        {
            { Parent: null } => NodeType.Root,
            { Property: null } => NodeType.Element,
            { Value: IEnumerable value } when
                value.GetType().IsArray ||
                value.GetGenericType() is not null => NodeType.Enumerable,
            _ => NodeType.Primitive
        }, node) switch
        {
            { Item1: NodeType.Enumerable, Item2.Value: { } value } when value.GetGenericType()?.IsSystem() ?? false
                => NodeType.PrimitiveEnumerable,
            { Item1: var nodeType } => nodeType
        };

        public static IEnumerable<INode> GetBranch(this INode? node)
        {
            while (node is not null)
            {
                yield return node;
                node = node.Parent;
            }
        }
    }

    public interface INode
    {
        public INode? Parent { get; }
        public object? Value { get; }
        public object? ActualValue { get; }
        public PropertyData? Property { get; }
        public NodeType Type { get; }
    }

    [DebuggerDisplay("{Value}")]
    public class Node : INode
    {
        public Node(
            object? value,
            INode? parent = null,
            PropertyData? property = null)
        {
            Parent = parent;
            Value = value;
            Property = property;
            Type = Nodes.GetType(this);
            if(Type == NodeType.Enumerable)
            {
                Value = (Value as IEnumerable)
                    ?.Cast<object>()
                    .ToImmutableArray();
            }
        }

        public INode? Parent { get; }
        public object? Value { get; }
        public object? ActualValue => Property is not null ? 
            Parent?.Value?.GetValueOf(Property) : 
            Value;
        public PropertyData? Property { get; }
        public NodeType Type { get; }


        //public string ReferencedPath => IsReferenced ? Path.Substring(Reference?.Path.Length ?? Path.Length) : string.Empty;
    }
}
