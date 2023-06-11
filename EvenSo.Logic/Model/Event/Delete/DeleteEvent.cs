namespace EvenSo.Logic.Model.Event
{
    public sealed record DeleteEvent
    (
        Guid Id,
        object PartitionKey,
        DateTime CreationDate,
        IReadOnlyDictionary<string, object> EntityKeys,
        EventType EventType,
        IEnumerable<Reference> SubReferences
    ) : IDeleteEvent;
}
