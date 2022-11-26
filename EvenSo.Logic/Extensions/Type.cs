#region Usings

using EvenSo.Keys;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;

#endregion

namespace EvenSo.Logic.Extensions
{
    public static class TypeCach
    {
        private static readonly Dictionary<Type, TypeData> _cache = new();

        public static bool HasKeys(this Type type, params KeyType[] keyTypes) =>
            type.GetCache().HasKeys(keyTypes);

        public static bool HasKeys(this object item, params KeyType[] keyTypes) =>
            item.GetType().GetCache().HasKeys(keyTypes);

        public static PropertyData? GetKey(this Type type, KeyType keyType) =>
            type.GetCache().GetKey(keyType);

        public static PropertyData? GetKey(this object item, KeyType keyType) =>
            item.GetType().GetCache().GetKey(keyType);

        public static object? GetKeyValue(this object item, KeyType keyType) =>
            item.GetKey(keyType)?.GetValue(item);

        public static IEnumerable<PropertyData> GetKeys(this Type type) =>
            type.GetCache().Keys;

        public static IEnumerable<PropertyData> GetKeys(this object item) =>
            item.GetType().GetCache().Keys;

        public static bool IsEnumerable(this Type type) =>
            type.GetInterface(nameof(IEnumerable)) is not null;

        public static Type? GetGenericType(this Type type) =>
            type.GetGenericArguments().FirstOrDefault();

        public static Type? GetGenericType(this object item) => item.GetType().GetGenericType();

        public static IEnumerable<PropertyData> GetProperties(this object item) =>
            item.GetCache().Properties;

        public static object? GetValueOf(this object item, PropertyData property) =>
            property.GetValue(item);

        public static bool IsSystem(this Type type) =>
            type.Namespace?.StartsWith("System") ?? false;

        public static bool IsSystem(this object item) => item.GetType().IsSystem();

        public static bool IsNotSystem(this Type type) => !type.IsSystem();

        public static bool IsNotSystem(this object item) => !item.GetType().IsSystem();

        private static TypeData GetCache(this Type type) =>
            _cache.TryGetValue(type, out var props) ? props : Cach(type);
 
        private static TypeData GetCache(this object item) => item.GetType().GetCache();

        private static TypeData Cach(Type type)
        {
            var data = new TypeData(type);
            _cache.Add(type, data);
            return data;
        }
    }

    public sealed class TypeData
    {
        internal TypeData(Type type)
        {
            Properties = type
                .GetProperties()
                .Select(propertyInfo => new PropertyData(propertyInfo));

            try
            {
                Keys = Properties.GetKeys(checkMultiple: true);
            } 
            catch (Exceptions.KeyException keyException)
            {
                throw new Exceptions.TypeException(type.Name + 
                    (keyException?.KeyTypes?.Any() ?? false ? 
                    $" has multiple {string.Join(" and ", keyException.KeyTypes)}" 
                    : string.Empty), type);
            }
        }

        internal IEnumerable<PropertyData> Properties { get; }
        internal IEnumerable<PropertyData> Keys { get; }

        internal bool HasKeys(params KeyType[] keyTypes) =>
            keyTypes.All(keyType => Keys.Select(key => key.KeyType).Contains(keyType));
        
        internal PropertyData? GetKey(KeyType keyType) => Keys.SingleOrDefault(key => key.KeyType == keyType);
    }

    [DebuggerDisplay("{Name}")]
    public sealed class PropertyData
    {
        private readonly object _getMethod;

        internal PropertyData(PropertyInfo propertyInfo)
        {
            Type = propertyInfo.PropertyType;
            Name = propertyInfo.Name;
            KeyType = propertyInfo.GetKeyType();

            _getMethod = Delegate.CreateDelegate(typeof(Func<,>).MakeGenericType(propertyInfo.DeclaringType!, Type), propertyInfo.GetGetMethod()!);
        }

        public KeyType KeyType { get; }
        public bool IsKey => KeyTypes.IsKey(KeyType);
        public Type Type { get; }
        public string Name { get; }
        public object? GetValue(object item) => ((dynamic)_getMethod)((dynamic)item);
    }
}
