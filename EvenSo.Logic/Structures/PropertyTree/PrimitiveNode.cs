using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace EvenSo.Logic.Structures.PropertyTree
{
    [DebuggerDisplay("{Name}: {Value}")]
    public class PrimitiveNode : IPropertyNode
    {
        public PrimitiveNode(Func<object?> getter, string name, IPropertyNode? parent)
        {
            _getter = getter;
            _value = _getter();
            Name = name;
            Parent = parent;

            Children = Enumerable.Empty<IPropertyNode>();
        }

        private object? _value;
        private readonly Func<object?> _getter;

        public string Name { get; }

        public object? Value => _value = _getter();

        public IPropertyNode? Parent { get; }

        public IEnumerable<IPropertyNode> Children { get; }

        public IEnumerable<IChange> Changes => (Old: _value, New: Value) is var value &&
            (!value.Old?.Equals(value.New) ?? value.New is not null) ?
                new[]
                {
                    new Change
                    {
                        ChangeType = ChangeType.NewValue,
                        Value = value.New,
                    } 
                } : 
                Enumerable.Empty<IChange>();
    }
}
