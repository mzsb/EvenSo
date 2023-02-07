using System.Runtime.InteropServices;

namespace EvenSo
{
    public static class Span
    {
        public static ReadOnlySpan<T> ToReadOnlySpan<T>(this IEnumerable<T> values) => 
            CollectionsMarshal.AsSpan(values.ToList());
    }
}
