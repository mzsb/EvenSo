namespace EvenSo
{
    internal static class IEnumerables
    {
        public static IEnumerable<T> HasMultiples<T, K>(
            this IEnumerable<T> items, 
            Func<T, K> like, 
            Action<IEnumerable<T>>? onMultiples = default)
        {
            if(items.GroupBy(item => like(item))
                      .Where(group => group.Count() > 1)
                      .Select(group => group.First()) is { } multiples &&
                multiples.Any())
            {
                if(onMultiples is not null)
                {
                    onMultiples(multiples);
                }
                else 
                { 
                    throw new EvensoException<IEnumerable<T>>(
                        typeName: typeof(T).Name,
                        message: $"{{ {string.Join(" ; ", multiples.Select(item => like(item)))} }} appeared multiple times.", 
                        cause: multiples); 
                }
            }

            return items;
        }
    }
}
