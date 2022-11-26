#region Usings

using EvenSo.Logic.Exceptions;
using EvenSo.Logic.Extensions;
using System.Reflection;

#endregion


namespace EvenSo.Keys
{
    public enum KeyType
    {
        None = 1,
        Id = 2,
        PartitionKey = 4
    }

    public static class KeyTypes
    {
        public static bool IsKey(KeyType keyType) => keyType != KeyType.None;

        public static IEnumerable<PropertyData> GetKeys(this IEnumerable<PropertyData> properties, bool checkMultiple)
        {
            var keys = properties.Where(property => property.IsKey);

            if (checkMultiple &&
                keys.GroupBy(key => key.KeyType)
                    .Where(keyGroup => keyGroup.Count() > 1) is { } notUniques &&
                notUniques.Any())
            {
                throw new KeyException("Multiple keys.", notUniques.Select(group => group.Key));
            }

            return keys;
        }

        public static KeyType GetKeyType(this PropertyInfo propertyInfo) =>
            Enum.GetValues(typeof(KeyType)).Cast<KeyType?>()
                .SingleOrDefault(keyType => propertyInfo.Name == $"{keyType}" || propertyInfo.Name == $"{propertyInfo?.DeclaringType?.Name}{keyType}") ??
                    propertyInfo.GetCustomAttribute<KeyAttribute>()?.KeyType ?? KeyType.None;
    }
}
