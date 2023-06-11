#region Usings

using EvenSo.Logic.Attributes;
using EvenSo.Logic.Structures.Value;
using EvenSo.Logic.Structures.Visitor;
using System.Collections;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection;

#endregion

namespace EvenSo.Logic.Structures.Node
{
    [DebuggerDisplay("{Value}")]
    internal sealed class EnumerableNode : IEnumerableNode
    {
        private readonly ICollection<INode> _children = new List<INode>();

        private EnumerableNode
        (
            Func<object?> valueGetter,
            string name,
            INode parent,
            Type? referenceType
        )
        {
            Value = valueGetter.ToEnumerableChangeableValue();
            Name = name;
            Parent = parent;
            ReferenceType = referenceType;

            _children = CreateChildren(Value.Actual).ToList();
        }

        internal EnumerableNode
        (
            object? value,
            string name,
            INode parent,
            Type? referenceType = null
        ) : this(() => value, name, parent, referenceType) { }

        internal EnumerableNode
        (
            PropertyInfo property,
            INode parent
        ) : this(() => property.GetValue(parent.Value), property.Name, parent, property.GetReferenceType()) { }

        public IEnumerator<object?> GetEnumerator() => Children.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public string Name { get; }

        public IChangeableValue<IEnumerable<object?>> Value { get; }

        public Type? ReferenceType { get; }

        public INode Parent { get; }

        public IEnumerable<INode> Children => _children.ToImmutableArray();

        public void Accept(INodeVisitor visitor)
        {
            visitor.Visit(this);

            foreach (var child in Children)
            {
                child.Accept(visitor);
            }
        }

        public (IEnumerable<INode> Removed, IEnumerable<INode> Added) UpdateChildren()
        {
            IEnumerable<INode> removedChildren = Enumerable.Empty<INode>();
            if (Value.Actual is not null)
            {
                var distinctNewValues = Value.Actual.Distinct().ToArray();

                removedChildren = _children
                    .Where(oldChild => distinctNewValues.Contains(oldChild.Value))
                    .ToImmutableArray();

                foreach (var removedChild in removedChildren)
                {
                    _children.Remove(removedChild);
                }
            }

            IEnumerable<INode> addedChildren = Enumerable.Empty<INode>();
            if (Value.Old is not null)
            {
                var distinctOldValues = Value.Old.Distinct().ToArray();

                addedChildren = CreateChildren(Value.Actual)
                    .Where(newChild => distinctOldValues.Contains(newChild.Value))
                    .ToImmutableArray();

                foreach (var addedChild in addedChildren)
                {
                    _children.Add(addedChild);
                }
            }

            return (removedChildren, addedChildren);
        }

        private IEnumerable<INode> CreateChildren(IEnumerable<object?>? value) => value
        ?.Select<object?, INode>
        (
            (element, index) =>
            {
                if (element is null || element.IsPrimitive())
                {
                    return new PrimitiveNode(value: element, name: index.ToString(), parent: this, ReferenceType);
                }

                if (element.IsEnumerable())
                {
                    return new EnumerableNode(value: element, name: index.ToString(), parent: this, ReferenceType);
                }

                return new ObjectNode(value: element, name: index.ToString(), parent: this, ReferenceType);
            }
        )
        ?? Enumerable.Empty<INode>();
    }
}
