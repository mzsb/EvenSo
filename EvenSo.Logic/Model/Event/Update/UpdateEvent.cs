namespace EvenSo.Logic.Model.Event
{
    public sealed record UpdateEvent
    (
        Guid Id,
        object PartitionKey,
        DateTime CreationDate,
        IReadOnlyDictionary<string, object> EntityKeys,
        EventType EventType,
        IReadOnlyDictionary<string, Change> Changes
    ) : IUpdateEvent;
}
