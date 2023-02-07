namespace EvenSo.Caches
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class KeyAttribute : Attribute
    {
        public KeyAttribute(KeyType keyType) { KeyType = keyType; }

        internal KeyType KeyType { get; }
    }
}
