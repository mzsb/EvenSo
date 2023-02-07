#region Usings

using System.Diagnostics;
using System.Reflection;

#endregion

namespace EvenSo.Caches
{
    [DebuggerDisplay("{Name}")]
    public class PropetyInfoo
    {
        private readonly MethodInfo? _getMethod;

        public PropetyInfoo(PropertyInfo propertyInfo)
        {
            PropertyInfo = propertyInfo;

            _getMethod = propertyInfo.GetGetMethod()!;
        }

        public PropertyInfo PropertyInfo { get; }

        public object? GetValue(object item) => _getMethod?.Invoke(item, null);
    }

    public static class PropertyCacheItems
    {
        public static PropetyInfoo[] GetCachedProperties(this Type type) =>
            type.GetCachedType().Properties;

        public static PropetyInfoo[] GetCachedProperties(this object item) =>
            item.GetType().GetCachedType().Properties;

        public static object? GetValueOf(this object item, PropetyInfoo property) =>
            property.GetValue(item);
    }
}
