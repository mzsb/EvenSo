namespace EvenSo.Client.Test.Model
{
    public static class PropertyChachFunc<T>
    {
        public static readonly IReadOnlyCollection<Func<T, object>> Chach = typeof(T).GetProperties().Select(p =>
            (Func<T, object>)Delegate.CreateDelegate(typeof(Func<T, object>), p.GetGetMethod()!)
        ).ToList();
    }
}
