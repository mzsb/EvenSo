#region Usings

using System.Collections.Concurrent;

#endregion

namespace EvenSo.Caches
{
    public sealed class TypeCache : ConcurrentDictionary<Type, TypeCacheItem>
    {
        static TypeCache() { }

        private TypeCache() { }
        
        public static readonly TypeCache Intsance = new();

        public TypeCacheItem GetCachedType(Type type) =>
            GetOrAdd(type, type => new TypeCacheItem(type));
    }
}
