#region Usings

using EvenSo.Logic.Attributes.Reference;
using System.Reflection;

#endregion

namespace EvenSo.Logic.Attributes
{
    internal static class KeyAttributeHelper
    {
        internal static KeyAttribute? GetKeyAttribute(this PropertyInfo property) =>
            property.GetCustomAttribute<KeyAttribute>();

        internal static Type? GetReferenceType(this PropertyInfo property) =>
            property.GetCustomAttribute<ReferenceAttribute>()?.EntityType ?? property.DeclaringType;
    }
}
