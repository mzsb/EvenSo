using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Windows.Markup;

namespace EvenSo.Logic.Structures.PropertyTree
{
    [DebuggerDisplay("{Name}: {Value}")]
    public class EnumerableNode : IPropertyNode
    {
        public EnumerableNode(
            Func<object?> getter,
            string name,
            IPropertyNode? parent)
        {

            _getter = () => ((IEnumerable)getter()!).Cast<object?>();
            _value = _getter().ToArray();
            _hashes = string.Join("", _getter().Select(element => $"{element?.GetHashCode() ?? 0}").OrderBy(hash => hash));
            Name = name;
            Parent = parent;
        }

        private string _hashes = string.Empty;
        private IEnumerable<object?> _value;
        private readonly Func<IEnumerable<object?>> _getter;

        public string Name { get; }

        public object? Value => _value = _getter().ToArray();

        public IPropertyNode? Parent { get; }

        private IPropertyNode[]? _children;
        public IEnumerable<IPropertyNode> Children => _children ??= _value
            .Select((element, idx) => NodeFactory.Create(element, idx.ToString(), this))
            .ToArray();

        public IEnumerable<IChange> Changes 
        {
            get
            {
                var newHashes = string.Join("", _getter().Select(element => $"{element?.GetHashCode() ?? 0}").OrderBy(hash => hash));

                if(_hashes != newHashes)
                {
                    _ = 0;
                }

                return Enumerable.Empty<IChange>();
            }
        }
        //{
        //    get
        //    {
        //        var value = (Old: _value, New: ((IEnumerable)Value!).Cast<object?>());
        //        var changes = new List<IChange>();
        //        if(Value is IEnumerable<object?> newValue && 
        //           _value is IEnumerable<object?> oldValue)
        //        {
        //            changes.AddRange(oldValue.Where(item => !newValue.Contains(item)).Select(item => new Change
        //            {
        //                ChangeType = ChangeType.OldElement,
        //                Value = item
        //            }));

        //            changes.AddRange(newValue.Where(item => !oldValue.Contains(item)).Select(item => new Change
        //            {
        //                ChangeType = ChangeType.NewElement,
        //                Value = item
        //            }));
        //        }
        //        else
        //        {
        //            changes.Add(value switch
        //            {
        //                (null, null) => null,

        //                (null, not null) => 
                        
        //                    new Change
        //                    {
        //                        ChangeType = ChangeType.NewValue,
        //                        Value = value.New
        //                    }
        //                ,

        //                (not null, null) => 
                        
        //                    new Change
        //                    {
        //                        ChangeType = ChangeType.NewValue,
        //                        Value = null
        //                    }
        //                ,
        //            });
        //        }



        //        return changes;
        //    }
        //}

        //private IEnumerable<IMultiplicable>? multiples;
        //public override IEnumerable<IMultiplicable> Multiples => multiples??= Value.New is { } value ?
        //    ((IEnumerable)Value.New)
        //    .Cast<object?>()
        //    .Select((element, idx) => 
        //        PropertyValueFactory.Create(() => element, idx.ToString()))
        //    .ToArray()
        //    : Enumerable.Empty<IMultiplicable>();

        //public virtual IEnumerable<IPropertyValue> Changes
        //{
        //    get
        //    {
        //        if(Value.Old is IEnumerable<object?> old && 
        //           Value.New is IEnumerable<object?> @new)
        //        {
        //            return old.Where(item => !@new.Contains(item));
        //        }

        //        return Enumerable.Empty<IPropertyValue>();
        //    }
        //}
    }
}
