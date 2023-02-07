#region Usings

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

#endregion

namespace EvenSo.PropertyTrees
{
    //#if DEBUG
    //[DebuggerDisplay("{Value}")]
    //#endif
    //public sealed class PropertyNode 
    //{
    //    public PropertyCacheItem? Property { get; init; }

    //    public object? Value { get; init; }

    //    public PropertyNode? Parent { get; init; }

    //    private PropertyNodeType? _type;
    //    public PropertyNodeType Type => _type ??= new Func<PropertyNodeType>(() =>
    //    {
    //        var type = Node;
    //        if ((Value?.GetType() ?? Property?.PropertyType) is { } valueType)
    //        {
    //            if (valueType.IsEnumerable() &&
    //                valueType.GetEnumerableType() is { } enumerableType)
    //            {
    //                type |= Collection;

    //                valueType = enumerableType;
    //            }

    //            type |= valueType.IsPrimitive() ? External : Internal;
    //        }

    //        return type;
    //    })();

    //    public IEnumerable<PropertyNode> Children { get; set; } = Enumerable.Empty<PropertyNode>();

    //    public IEnumerable<PropertyNode> Branch
    //    {
    //        get
    //        {
    //            PropertyNode? node = this;
    //            do
    //            {
    //                yield return node;
    //                node = node.Parent;
    //            } while (node is not null);
    //        }
    //    }

    //    //public object? NewValue
    //    //{
    //    //    get
    //    //    {
    //    //        object? newValue = null;
    //    //        if (Property is not null &&
    //    //            Parent is not null)
    //    //        {
    //    //            newValue = Parent.GetValueOf(Property);

    //    //            if (newValue is not null &&
    //    //               Type.IsPartially(Collection))
    //    //            {
    //    //                newValue = ((IEnumerable<object?>)newValue).ToArray();
    //    //            }
    //    //        }

    //    //        return newValue;
    //    //    }
    //    //}

    //    //public bool IsChanged => Type switch
    //    //{
    //    //    _ when Type.IsPartially(Null) => NewValue is not null,

    //    //    External => NewValue?.Equals(Value!) ?? true,

    //    //    External_Collection =>
    //    //        ((IEnumerable<object?>)NewValue).ToHashSet().SequenceEqual((IEnumerable<object?>)NewValue),



    //    //    Internal => ReferenceEquals(Value!, NewValue),

    //    //}
    //}

    #if DEBUG
    [DebuggerDisplay("{Value}")]
    #endif

    public sealed class PropertyNode2
    {
        public PropertyNode2(Func<object?> value, char[] name)
        {
            Value = value;
            var _value = Value();
            if (_value is { } vvalue && vvalue.IsPrimitive())
            {
                RawValue = JsonConvert.SerializeObject(_value).ToArray();
            }
            Name = name;
            Children = _value switch
            {
                null => Enumerable.Empty<PropertyNode2>(),

                not IEnumerable when _value.IsNotPrimitive() =>
                    _value
                    .GetType()
                    .GetProperties()
                    .Select(property => new PropertyNode2(() => property.GetValue(_value), property.Name.ToArray())
                    {
                        Parent = this,
                    }),

                IEnumerable when _value.GetEnumerableType()?.IsNotPrimitive() ?? false =>
                    ((IEnumerable<object?>)_value)
                    .Select((element, idx) => new PropertyNode2(() => element, idx.ToString().ToArray())
                    {
                        Parent = this
                    }),

                _ => Enumerable.Empty<PropertyNode2>()
            };
        }

        public Func<object?> Value { get; }

        public object? ObjValue => Value();

        public char[] RawValue { get; } = Array.Empty<char>();

        public char[] NewValue => Value() is { } vvalue && vvalue.IsPrimitive() ?
            JsonConvert.SerializeObject(vvalue).ToArray() :
            Array.Empty<char>();

        public bool IsChanged()
        {
            for (int i = 0; i < RawValue.Length; i++)
            {
                if (RawValue[i] != NewValue[i]) return true;
            }

            return false;
        }

        public char[]? Name { get; }

        public PropertyNode2? Parent { get; init; }

        public IEnumerable<PropertyNode2> Children { get; } = Enumerable.Empty<PropertyNode2>();

        public IEnumerable<PropertyNode2> Branch
        {
            get
            {
                var node = this;
                do
                {
                    yield return node;
                    node = node.Parent;
                } while (node is not null);
            }
        }
    }

    #if DEBUG
    [DebuggerDisplay("{ObjValue}")]
    #endif
    public sealed class PropertyNode3
    {
        public PropertyNode3(Func<object?> value, char[] name)
        {
            Value = value;
            var _value = Value();
            if (_value is { } vvalue && vvalue.GetType().IsSerializable)
            {
                RawValue = JsonConvert.SerializeObject(_value).ToArray();
            }
            Name = name;
            Children = _value switch
            {
                null => Enumerable.Empty<PropertyNode3>(),

                not IEnumerable when _value.IsNotPrimitive() =>
                    _value
                    .GetType()
                    .GetProperties()
                    .Select(property => new PropertyNode3(() => property.GetValue(_value), property.Name.ToArray())
                    {
                        Parent = this,
                    }),

                IEnumerable when _value.GetEnumerableType()?.IsNotPrimitive() ?? false =>
                    ((IEnumerable<object?>)_value)
                    .Select((element, idx) => new PropertyNode3(() => element, idx.ToString().ToArray())
                    {
                        Parent = this
                    }),

                _ => Enumerable.Empty<PropertyNode3>()
            };
        }

        public Func<object?> Value { get; }

        public object? ObjValue => Value();

        public char[] RawValue { get; } = Array.Empty<char>();

        public char[] NewValue => Value() is { } vvalue && vvalue.GetType().IsSerializable ? 
            JsonConvert.SerializeObject(Value()).ToArray() :
            Array.Empty<char>();

        public bool IsChanged()
        {
            for (int i = 0; i < RawValue.Length; i++)
            {
                if (RawValue[i] != NewValue[i]) return true;
            }

            return false;
        }

        public char[]? Name { get; }

        public PropertyNode3? Parent { get; init; }

        public IEnumerable<PropertyNode3> Children { get; } = Enumerable.Empty<PropertyNode3>();

        public IEnumerable<PropertyNode3> Branch
        {
            get
            {
                var node = this;
                do
                {
                    yield return node;
                    node = node.Parent;
                } while (node is not null);
            }
        }
    }
}
