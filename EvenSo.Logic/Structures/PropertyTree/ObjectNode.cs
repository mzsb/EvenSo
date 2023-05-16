using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace EvenSo.Logic.Structures.PropertyTree
{
    [DebuggerDisplay("{Name}: {Value}")]
    public class ObjectNode : IPropertyNode
    {
        public ObjectNode(
            Func<object?> getter,
            string name,
            IPropertyNode? parent)
        {
            _getter = getter;
            _value = _getter();
            Name = name;
            Parent = parent;

            Children = Value?
                .GetType()
                .GetProperties()
                .Select(property => 
                    {

                        return NodeFactory.Create(property, this); 
                    })
                .ToArray() ?? Enumerable.Empty<IPropertyNode>();
        }

        private object? _value;
        private readonly Func<object?> _getter;

        //public object? Value { get; }
        //public string Name { get; }

        ////public virtual bool IsChanged => Value switch 
        ////{
        ////    (not null, not null) value => !value.New.Equals(value.Old),

        ////    (null, null) => false,

        ////    _ => true
        ////};

        ////public virtual IEnumerable<IPropertyValue> Changes => Value switch
        ////{
        ////    (not null, not null) value when !value.New.Equals(value.Old) => new[] { this },

        ////    (null, null) => Enumerable.Empty<IPropertyValue>(),

        ////    _ => new[] { this }
        ////};

        public string Name { get; }

        public object? Value => _value = _getter();

        public IPropertyNode? Parent { get; }

        public IEnumerable<IPropertyNode> Children { get; }

        public IEnumerable<IChange> Changes => Enumerable.Empty<IChange>();
            //Children.All(child => child.Changes.Any()) ? 
            //    new[] { this } :
            //    Children
            //        .Where(child => child.Changes.Any())
            //    .ToArray();
    }
}
