namespace EvenSo
{
    internal sealed class EvensoException<T> : Exception
    {
        internal EvensoException(string message, T cause, string? typeName = default, Exception? innerException = default)
            : base($"{(string.IsNullOrEmpty(typeName) ? typeof(T).Name : typeName)} error occurred. {message}", innerException)
        {
            if (cause is not null) { Data.Add(cause, message); }
        }
    }
}

