#region Usings

using EvenSo.Logic.Attributes;
using EvenSo.Logic.Structures.Value;
using EvenSo.Logic.Structures.Visitor;
using System.Diagnostics;
using System.Reflection;

#endregion

namespace EvenSo.Logic.Structures.Node
{
    [DebuggerDisplay("{Value}")]
    internal sealed class PrimitiveNode : IPrimitiveNode
    {
        private PrimitiveNode
        (
            Func<object?> valueGetter,
            string name,
            INode parent,
            Type? referenceType
        )
        {
            Value = valueGetter.ToChangeableValue();
            Name = name;
            Parent = parent;
            ReferenceType = referenceType;
        }

        internal PrimitiveNode
        (
            object? value,
            string name,
            INode parent,
            Type? referenceType = null
        ) : this(() => value, name, parent, referenceType) { }

        internal PrimitiveNode
        (
            PropertyInfo property,
            INode parent
        ) : this(() => property.GetValue(parent.Value), property.Name, parent, property.GetReferenceType()) { }

        public string Name { get; }

        public IChangeableValue<object?> Value { get; }

        public Type? ReferenceType { get; }

        public INode Parent { get; }

        public IEnumerable<INode> Children => Enumerable.Empty<INode>();

        public void Accept(INodeVisitor visitor) => visitor.Visit(this);
    }
}
