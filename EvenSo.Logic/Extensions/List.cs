#region Usings

using System.Runtime.InteropServices;

#endregion

namespace EvenSo.Logic.Extensions
{
    public static class List
    {
        public static ReadOnlySpan<T> ToReadOnlySpan<T>(this IEnumerable<T> items) =>
            CollectionsMarshal.AsSpan(items.ToList());

    }
}
