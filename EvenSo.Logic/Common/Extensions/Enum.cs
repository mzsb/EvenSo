namespace EvenSo
{
    public static class Enums
    {
        public static bool IsPartially<T>(this T type, T otherTypes) where T : Enum =>
            ((int)(IConvertible)type & (int)(IConvertible)otherTypes) != 0;
        public static bool IsNotPartially<T>(this T type, T otherTypes) where T : Enum =>
            !type.IsPartially(otherTypes);
    }
}
