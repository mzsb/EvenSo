namespace EvenSo.Logic.Model.Event
{
    public interface IDeleteEvent : IEvent
    {
        IEnumerable<Reference> SubReferences { get; }
    }
}
