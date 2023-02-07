using System.Reflection;

namespace EvenSo.Caches
{
    internal sealed class Key : PropetyInfoo
    {
        internal Key(KeyType keyType, PropertyInfo propertyInfo) : base(propertyInfo) 
        {
            KeyType = keyType;
        }

        internal KeyType KeyType { get; }

        internal static KeyType? GetKeyType(PropertyInfo propertyInfo) =>
            Enum.GetValues(typeof(KeyType)).Cast<KeyType?>()
                .SingleOrDefault(
                    keyType => propertyInfo.Name == $"{keyType}" || 
                    propertyInfo.Name == $"{propertyInfo?.DeclaringType?.Name}{keyType}") ??
                        propertyInfo.GetCustomAttribute<KeyAttribute>()?.KeyType;
    }

    internal static class Keys
    {
        internal static KeyType? GetKeyType(this PropertyInfo propertyInfo) =>
            Key.GetKeyType(propertyInfo);

        internal static bool Has(this Type type, KeyType keyType) =>
            type.GetCachedType().HasKey(keyType);

        internal static bool HasNo(this Type type, KeyType keyType) =>
            !type.Has(keyType);

        internal static bool Has(this object item, KeyType keyTypes) =>
            item.GetType().Has(keyTypes);

        internal static bool HasNo(this object item, KeyType keyTypes) =>
            !item.GetType().Has(keyTypes);

        internal static bool Has(this Type type, params KeyType[] keyTypes) =>
            type.GetCachedType().HasKeys(keyTypes);

        internal static bool Has(this object item, params KeyType[] keyTypes) =>
            item.GetType().IsNotPrimitive() && item.GetType().GetCachedType().HasKeys(keyTypes);

        internal static IEnumerable<Key> GetKeys(this Type type) =>
            type.IsNotPrimitive() ? type.GetCachedType().Keys : Enumerable.Empty<Key>();

        internal static IEnumerable<Key> GetKeys(this object item) =>
            item.GetType().GetCachedType().Keys;

        internal static Key? GetKey(this Type type, KeyType keyType) =>
            type.IsNotPrimitive() ? type.GetCachedType().GetKey(keyType) : null;

        internal static Key? GetKey(this object item, KeyType keyType) =>
            item.GetType().GetCachedType().GetKey(keyType);

        internal static object? GetKeyValue(this object item, KeyType keyType) =>
            item.GetKey(keyType)?.GetValue(item);
    }
}
