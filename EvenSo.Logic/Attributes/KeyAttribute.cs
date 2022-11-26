namespace EvenSo.Keys
{
    [AttributeUsage(AttributeTargets.Property)]
    public class KeyAttribute : Attribute
    {
        public KeyType KeyType { get; }

        public KeyAttribute(KeyType keyType) { KeyType = keyType; }
    }
}
