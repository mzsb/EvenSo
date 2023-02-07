namespace EvenSo.Events
{
    internal sealed class Create : Event 
    {
        internal override EventType Type => EventType.Create;
    }
}
