namespace EvenSo.Logic.Model.Event
{
    public interface IUpdateEvent : IEvent
    {
        IReadOnlyDictionary<string, Change> Changes { get; }
    }
}
