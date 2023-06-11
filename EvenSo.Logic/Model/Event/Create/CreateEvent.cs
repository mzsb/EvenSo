namespace EvenSo.Logic.Model.Event
{
    public sealed record CreateEvent
    (
        Guid Id,
        object PartitionKey,
        DateTime CreationDate,
        IReadOnlyDictionary<string, object> EntityKeys,
        EventType EventType,
        object InitialValue,
        IEnumerable<Reference> SubReferences
    ) : ICreateEvent;
}
