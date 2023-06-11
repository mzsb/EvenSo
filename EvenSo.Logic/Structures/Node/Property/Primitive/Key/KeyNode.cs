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
    internal sealed class KeyNode : IKeyNode
    {
        internal KeyNode
        (
            Type keyType,
            Type? entityType,
            PropertyInfo property,
            INode parent
        )
        {
            Value = new ObjectNodeValue(() => property.GetValue(parent.Value));
            Name = property.Name;
            ReferenceType = property.GetReferenceType();
            Parent = parent;
            KeyType = keyType;
            EntityType = entityType ?? throw new Exception();
        }

        public string Name { get; }

        public IChangeableValue<object?> Value { get; }

        public Type? ReferenceType { get; }

        public INode Parent { get; }

        public Type KeyType { get; }

        public object KeyValue => Value.Actual ?? 
            throw new Exception($"{EntityType.Name} {KeyType.Name} cannot be null.");

        public Type EntityType { get; }

        public IEnumerable<INode> Children => Enumerable.Empty<INode>();

        public void Accept(INodeVisitor visitor) => visitor.Visit(this);
    }
}
