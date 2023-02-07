namespace EvenSo.Events
{
    internal sealed class Delete : Event
    {
        internal override EventType Type => EventType.Delete;
    }
}
