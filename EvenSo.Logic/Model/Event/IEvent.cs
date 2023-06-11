namespace EvenSo.Logic.Model.Event
{
    public interface IEvent
    {
        Guid Id { get; }

        object PartitionKey { get; }

        DateTime CreationDate { get; }

        IReadOnlyDictionary<string, object> EntityKeys { get; }

        EventType EventType { get; }
    }
}
