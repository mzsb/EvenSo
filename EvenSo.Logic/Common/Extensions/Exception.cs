namespace EvenSo
{
    internal static class Exceptions
    {
        internal static bool Is<T>(this Exception exception, T type) where T : Enum => 
            Convert.ToInt32(type) == exception.HResult;
    }
}
