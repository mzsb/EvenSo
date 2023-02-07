#region Usings

using System.Collections;

#endregion

namespace EvenSo
{
    public static class Types
    {
        public static bool IsSystem(this Type type) =>
            type?.Namespace?.StartsWith("System") ?? false;

        public static bool IsNotSystem(this Type type) =>
            !type.IsSystem();

        public static bool IsSystem(this object item) =>
            item.GetType()?.Namespace?.StartsWith("System") ?? false;

        public static bool IsNotSystem(this object item) =>
            item.GetType().IsNotSystem();

        public static bool IsPrimitive(this Type type) =>
            type.IsPrimitive || PrimitiveLikeTypes.Contains(type);

        public static bool IsNotPrimitive(this Type type) => 
            !type.IsPrimitive();

        public static bool IsPrimitive(this object item) =>
            item.GetType().IsPrimitive();

        public static bool IsNotPrimitive(this object item) =>
            item.GetType().IsNotPrimitive();

        public static bool IsEnumerable(this Type type) => type.IsArray ||
            type.GetInterface(nameof(IEnumerable)) is not null;

        public static bool IsNotEnumerable(this Type type) =>
            !type.IsEnumerable();

        public static bool IsEnumerable(this object item) =>
            item.GetType().IsEnumerable();

        public static bool IsNotEnumerable(this object item) =>
            item.GetType().IsNotEnumerable();

        public static Type? GetEnumerableType(this Type type) =>
            type.GetGenericArguments().FirstOrDefault() ?? type.GetElementType();

        public static Type? GetEnumerableType(this object item) =>
            item.GetType().GetGenericArguments().FirstOrDefault() ?? item.GetType().GetElementType();
    }
}
