#region Usings

using EvenSo.Logic.Attributes;
using EvenSo.Logic.Structures.Value;
using EvenSo.Logic.Structures.Visitor;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection;

#endregion

namespace EvenSo.Logic.Structures.Node
{
    [DebuggerDisplay("{Value}")]
    internal sealed class ObjectNode : IObjectNode
    {
        private ObjectNode
        (
            Func<object?> valueGetter,
            string name,
            Type objectType,
            INode parent,
            Type? referenceType
        )
        {
            Value = valueGetter.ToChangeableValue();
            Name = name;
            Parent = parent;
            ObjectType = objectType;
            Children = CreateChildren(Value.Actual);
            Keys = GetKeys(from: this.GetSubNodes());
            ReferenceType = referenceType;
        }

        internal ObjectNode
        (
            object value,
            string name,
            INode parent,
            Type? referenceType = null
        ) : this(() => value, name, value.GetType(), parent, referenceType) { }

        internal ObjectNode
        (
            PropertyInfo property,
            INode parent
        ) : this(() => property.GetValue(parent.Value), property.Name, property.PropertyType, parent, property.GetReferenceType()) { }

        public string Name { get; } = string.Empty;

        public IChangeableValue<object?> Value { get; }

        public Type? ReferenceType { get; }

        public INode Parent { get; }

        public IEnumerable<INode> Children { get; private set; }

        public Type ObjectType { get; }

        public IEnumerable<IKeyNode> Keys { get; private set; }

        public void Accept(INodeVisitor visitor)
        {
            visitor.Visit(this);

            foreach (var child in Children)
            {
                child.Accept(visitor);
            }
        }

        public void UpdateChildren()
        {
            Children = CreateChildren(Value.Actual);
            Keys = GetKeys(from: this.GetSubNodes());
        }

        public bool Has<T>() where T : KeyAttribute =>
            Keys.Any(key => key.KeyType == typeof(T));

        public IKeyNode Get<T>() where T : KeyAttribute => Keys
            .SingleOrDefault(key => key.KeyType == typeof(T)) ?? throw new Exception();

        private IEnumerable<INode> CreateChildren(object? value) => value
            ?.GetType()
            ?.GetProperties()
            ?.Select<PropertyInfo, INode>
            (
                property =>
                {
                    if (property.PropertyType.IsPrimitive())
                    {
                        if (property.GetKeyAttribute() is { } keyAttribute)
                        {
                            return new KeyNode
                            (
                                keyType: keyAttribute.GetType(),
                                entityType: keyAttribute.EntityType,
                                property,
                                parent: this
                            );
                        }

                        return new PrimitiveNode(property, parent: this);
                    }

                    if (property.PropertyType.IsEnumerable())
                    {
                        return new EnumerableNode(property, parent: this);
                    }

                    return new ObjectNode(property, parent: this);
                }
            )
            ?.ToImmutableArray()
            ?? Enumerable.Empty<INode>();

        private IEnumerable<IKeyNode> GetKeys(IEnumerable<INode> from) => from
            .Where(child =>
                    child is IKeyNode keyChild &&
                    keyChild.EntityType == ObjectType)
            .Cast<IKeyNode>()
            .GroupBy(key => key.KeyType)
            .Select(group => group.Count() == 1 ? group.Single() :
                throw new Exception($"{ObjectType.FullName} has more than one {group.Key.Name}"))
            .ToImmutableArray();
    }
}
