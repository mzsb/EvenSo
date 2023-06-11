namespace EvenSo.Logic.Model.Event
{
    public interface ICreateEvent : IEvent
    {
        object InitialValue { get; }

        IEnumerable<Reference> SubReferences { get; }
    }
}
