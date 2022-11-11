#region Usings

using EvenSo.Logic.Attributes;
using System.Collections;
using System.Diagnostics;
using System.Reflection;

#endregion

namespace EvenSo.Logic.Extensions
{
    public static class MetadataCach
    {
        private static readonly Dictionary<Type, Metadata> _cachedMetadata = new();

        public static bool IsItem(this object item) =>
            item.GetCachedMetadata().IsItem;

        public static bool IsListItem(this object item) =>
            item.GetCachedMetadata().IsListItem;

        public static bool IsReference(this object item) =>
            item.GetCachedMetadata().IsReference;

        public static bool IsCollection(this Type type) =>
            type.IsGenericType && new[] { nameof(ICollection), nameof(IEnumerable) }
                .Any(@interface => type.GetInterface(@interface) is not null);

        public static bool IsCollection(this object item) => item.GetType().IsCollection();

        public static Type? GetCollectionType(this Type type) =>
            type.GetGenericArguments().FirstOrDefault();

        public static Type? GetCollectionType(this object item) => item.GetType().GetCollectionType();

        public static object? GetId(this object item) =>
            item.GetCachedMetadata().GetId(item);

        public static object? GetPartitionKey(this object item) =>
            item.GetCachedMetadata().GetPartitionKey(item);

        public static PropertyMetadata[] GetProperties(this object item) =>
            item.GetCachedMetadata().Properties;

        public static object? GetValueOf(this object item, PropertyMetadata property) =>
            property.GetValue(item);

        public static bool IsSystem(this Type type) =>
            type.Namespace?.StartsWith("System") ?? false;
        public static bool IsSystem(this object item) => item.GetType().IsSystem();

        public static bool IsNotSystem(this Type type) => !type.IsSystem();

        public static bool IsNotSystem(this object item) => !item.GetType().IsSystem();

        private static Metadata GetCachedMetadata(this Type type) =>
            _cachedMetadata.TryGetValue(type, out var props) ? props : CachMetaData(type);
 
        private static Metadata GetCachedMetadata(this object item) => item.GetType().GetCachedMetadata();

        private static Metadata CachMetaData(Type type)
        {
            var metadata = new Metadata(type);
            _cachedMetadata.Add(type, metadata);
            return metadata;
        }
    }

    public class Metadata
    {
        private readonly bool _isItem = false;
        private readonly bool _isListItem = false;
        private readonly bool _isReference = false;
        private readonly object[] _idGetters = Array.Empty<object>();
        private readonly object[] _partitionKeyGetters = Array.Empty<object>();
        private readonly PropertyMetadata[] _properties;



        internal Metadata(Type type)
        {
            if (type.GetCustomAttribute<ItemAttribute>(inherit: true) is { } itemAttribute)
            {
                _idGetters = GetGetters(type, itemAttribute.Id);
                _partitionKeyGetters = GetGetters(type, itemAttribute.PartitonKey);

                _isItem = _idGetters.Any() && _partitionKeyGetters.Any();
            }

            if (type.GetCustomAttribute<ListItemAttribute>(inherit: true) is { } listItemAttribute)
            {
                _idGetters = GetGetters(type, listItemAttribute.Id);
                _isListItem = _idGetters.Any();
            }

            if(type.GetCustomAttribute<ReferenceAttribute>(inherit: true) is { } referenceAttribute)
            {
                _idGetters = GetGetters(type, referenceAttribute.Id);
                _partitionKeyGetters = GetGetters(type, referenceAttribute.PartitonKey);
                _isReference = _idGetters.Any() && _partitionKeyGetters.Any();
            }

            _properties = type.GetProperties()
                .Select(propertyInfo => new PropertyMetadata(propertyInfo))
                .ToArray();
        }

        internal bool IsItem => _isItem;
        internal bool IsListItem => _isListItem;
        internal bool IsReference => _isReference;

        internal object? GetId(object obj) => Get(obj, _idGetters);

        internal object? GetPartitionKey(object obj) => Get(obj, _partitionKeyGetters);

        internal PropertyMetadata[] Properties => _properties;

        private static object[] GetGetters(Type type, string idPath)
        {
            var propertyType = type;
            var getters = new List<object>();
            foreach (var pathPart in idPath.Split('/'))
            {
                if (propertyType.GetProperty(pathPart) is PropertyInfo property)
                {
                    getters.Add(Delegate.CreateDelegate(
                        typeof(Func<,>).MakeGenericType(propertyType, property.PropertyType),
                        property!.GetGetMethod()!
                    ));
                    propertyType = property.PropertyType;
                }
                else return Array.Empty<object>();
            }

            return getters.ToArray();
        }

        private static object? Get(object obj, dynamic[] getters)
        {
            if (getters.Any())
            {
                foreach (var getter in getters)
                {
                    obj = getter((dynamic)obj);
                }
                return obj;
            }
            else return null;
        }
    }

    [DebuggerDisplay("{Name}")]
    public class PropertyMetadata
    {
        private readonly Type _type;
        private readonly string _name;
        private readonly object _getter;
        private readonly bool _isReferenced;
        private readonly bool _isCollection;
        private readonly Type? _collectionType;

        internal PropertyMetadata(PropertyInfo propertyInfo)
        {
            _type = propertyInfo.PropertyType;
            _name = propertyInfo.Name;
            _getter = Delegate.CreateDelegate(typeof(Func<,>).MakeGenericType(propertyInfo.DeclaringType!, propertyInfo.PropertyType), propertyInfo.GetGetMethod()!);
            _isReferenced = propertyInfo.IsDefined(typeof(ReferencedAttribute));
            _isCollection = propertyInfo.PropertyType.IsGenericType && new[] { nameof(ICollection), nameof(IEnumerable) }
                .Any(inerface => propertyInfo.PropertyType.GetInterface(inerface) is not null);
            if(_isCollection)
            {
                _collectionType = _type.GetGenericArguments()[0];
            }
        }

        public bool IsReferenced => _isReferenced;
        public Type Type => _type;
        public string Name => _name;
        public bool IsCollection => _isCollection;
        public Type? CollectionType => _collectionType;
        public object? GetValue(object obj) => ((dynamic)_getter)((dynamic)obj);
    }
}
