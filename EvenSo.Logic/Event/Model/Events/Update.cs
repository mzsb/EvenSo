namespace EvenSo.Events
{
    internal sealed class Update : Event
    {
        internal List<Segment> Segments { get; } = new();

        internal override EventType Type => EventType.Update;
    }

    internal sealed class Segment
    {
        internal string Path { get; set; } = string.Empty;

        internal string Value { get; set; } = string.Empty;

        internal string ReferenceId { get; set; } = string.Empty;
    }
}
