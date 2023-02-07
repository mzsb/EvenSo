namespace EvenSo.Caches
{
    public sealed class TypeCacheItem
    {
        public TypeCacheItem(Type type)
        {
            Properties = type
                .GetProperties()
                .Select(propertyInfo =>
                    propertyInfo.GetKeyType() is { } keyType ?
                        new Key(keyType, propertyInfo) :
                        new PropetyInfoo(propertyInfo)).ToArray();
            try
            {
                Keys = Properties
                    .Where(property => property is Key)
                    .Cast<Key>()
                    .HasMultiples(key => key.KeyType,
                        onMultiples: multiples =>
                        throw new EvensoException<IEnumerable<Key>>(
                            typeName: typeof(Key).Name,
                            message: $"Multiple {{ {string.Join(" ; ", multiples.Select(key => key.KeyType))} }} defined.",
                            cause: multiples)).ToArray();

                if (Keys.Any())
                {
                    KeyTypes = Keys
                        .Select(key => key.KeyType)
                        .Aggregate((current, next) => current | next);
                }
            }
            catch (EvensoException<IEnumerable<Key>> keyException)
            {
                throw new EvensoException<Type>($"Type of {type.Name}", type, innerException: keyException);
            }
        }

        internal Key[] Keys { get; }

        internal KeyType? KeyTypes { get; }

        public PropetyInfoo[] Properties { get; }

        internal bool HasKey(KeyType keyType) =>
            KeyTypes?.IsPartially(keyType) ?? false;

        internal bool HasKeys(params KeyType[] keyTypes) =>
            keyTypes.All(keyType => KeyTypes?.IsPartially(keyType) ?? false);

        internal Key? GetKey(KeyType keyType) => Keys.SingleOrDefault(key => key.KeyType == keyType);
    }

    public static class TypeCacheItems
    {
        public static TypeCacheItem GetCachedType(this Type type) =>
            TypeCache.Intsance.GetCachedType(type);
    }
}
