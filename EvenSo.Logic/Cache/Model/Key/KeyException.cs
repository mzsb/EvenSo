namespace EvenSo.Caches
{
    internal sealed class KeyException : Exception
    {
        internal KeyException(string? message = default, IEnumerable<Key>? keys = default) : base(message)
        {
            if(keys is not null)
            {
                Keys = keys;
            }
        }

        internal IEnumerable<Key> Keys { get; } = Array.Empty<Key>();
    }
}
