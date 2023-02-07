
using System;
using System.Reflection;

namespace EvenSo.Client.Test
{
    public static class PropertyCachProp
    {
        public static dynamic GetCache(Type type)
        {
            return typeof(PropertyCachProp<>).MakeGenericType(type).GetField("Cache", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
        }
    }

    public static class PropertyCachProp<T>
    {
        private static readonly dynamic Cache = typeof(T)
            .GetProperties()
            .Select(property => Delegate.CreateDelegate(
                typeof(Func<,>).MakeGenericType(typeof(T), property.PropertyType),
                property.GetGetMethod()!))
            .ToArray();
    }
}
