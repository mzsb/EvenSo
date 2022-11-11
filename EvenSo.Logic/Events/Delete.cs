using EvenSo.Logic.Enums;

namespace EvenSo.Logic.Events
{
    public sealed class Delete : Event
    {
        public override EventType Type => EventType.Delete;
    }
}
