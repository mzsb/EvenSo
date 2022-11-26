using System;
using System.Collections;
using System.Collections.Immutable;
using System.Diagnostics;

namespace EvenSo.Logic.Extensions
{

    public static class Nodess
    {
        public static IEnumerable<Node> GetNodess(this object item) 
        {
            var root  = new Node(item);
            while(root.Next is { } node)
            {
                yield return node;
            }
        }
    }

    [DebuggerDisplay("{Value}")]
    public class Node
    {
        private static readonly Stack<Node> _graph = new();
        public Node? Next => _graph.Count > 0 ? _graph.Pop() : null;
        public Node? Parent { get; init; }
        public object? Value { get; }
        public PropertyData? Property { get; init; }

        public Node(object? value)
        {
            Value = value;
            if (value is not null && 
                value.IsNotSystem())
            {
                foreach (var property in value.GetProperties())
                {
                    _graph.Push(new(value?.GetValueOf(property))
                    {
                        Parent = this,
                        Property = property
                    });
                }
            }
        }
    }
}
