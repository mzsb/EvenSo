namespace EvenSo.Logic.Exceptions
{
    internal class DatabaseException : Exception
    {
        internal DatabaseException(string? message) : base(message) { }
    }
}
