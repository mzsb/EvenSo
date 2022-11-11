#region Usings

using EvenSo.Logic.Exceptions;
using EvenSo.Logic.Extensions;
using EvenSo.Logic.Model;
using System.Reflection;
using Attribute = System.Attribute;

#endregion

namespace EvenSo.Logic.Attributes
{
    public abstract class AttributeBase : Attribute
    {
        //internal static bool Is<T>(PropertyInfo property) => property.IsNotNull(() => IsDefined(property, typeof(T)));

        internal static (string Name, object Value) Get<T>(object item) => item.IsNotNull(() =>
        {
            foreach (var property in item.GetType().GetProperties().ToReadOnlySpan())
            {
                if (IsDefined(property, typeof(T)))
                {
                    if (property.Name is { } name && property.GetValue(item) is { } value)
                    {
                        return (name, value);
                    }
                }
            }

            throw new ItemException($"{item.GetType().FullName} doesn't have {typeof(T).Name} attribute.");
        });
    }
}
