namespace EvenSo.Logic.Exceptions
{
    internal class TypeException : Exception
    {
        public Type? Type { get; }
        internal TypeException(string? message = default, Type? type = default) : base(message) 
        {
            Type = type;
        }
    }
}
