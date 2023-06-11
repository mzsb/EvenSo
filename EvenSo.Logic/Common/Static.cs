#region Usings

using Microsoft.Azure.Cosmos;
using System.Collections;

#endregion

namespace EvenSo.Logic
{
    internal static class TypeHelper
    {
        internal static bool IsPrimitive(this Type type) =>
            type.IsPrimitive || PrimitiveLikeTypes.Contains(type);

        internal static bool IsNotPrimitive(this Type type) =>
            !type.IsPrimitive();

        internal static bool IsPrimitive(this object item) =>
            item.GetType().IsPrimitive();

        internal static bool IsNotPrimitive(this object item) =>
            item.GetType().IsNotPrimitive();

        internal static bool IsEnumerable(this Type type) => type.IsArray ||
            type.GetInterface(nameof(IEnumerable)) is not null;

        internal static bool IsNotEnumerable(this Type type) =>
            !type.IsEnumerable();

        internal static bool IsEnumerable(this object item) =>
            item.GetType().IsEnumerable();

        internal static bool IsNotEnumerable(this object item) =>
            item.GetType().IsNotEnumerable();
    }

    internal static class PartitionKeyHelper
    {
        internal static PartitionKey ToCosmosPartitionKey(this object partitionKey) =>
            new(partitionKey.ToString());
    }

    internal static class DictionaryHelper
    {
        internal static void AddElement<T, K>
        (
            this IDictionary<T, ICollection<K>> dictionary,
            T key,
            K elementValue,
            Func<K, ICollection<K>>? collectionCreator = null
        )
        {
            collectionCreator ??= static elementValue => new List<K> { elementValue };

            if (dictionary.TryGetValue(key, out var values))
            {
                values.Add(elementValue);
            }
            else
            {
                dictionary.Add(key, collectionCreator(elementValue));
            }
        }
    }

    internal static class StringHelper
    { 
        internal static string ToCamelCase(this string? str) =>
            str?.Length > 1 ?
                char.ToLower(str[0]) + str[1..] :
                str?.ToLower()
            ?? string.Empty;
    }
}
