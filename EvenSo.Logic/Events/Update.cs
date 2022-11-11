using EvenSo.Logic.Enums;

namespace EvenSo.Logic.Events
{
    public sealed class Update : Event
    {
        public List<Segment> Segments { get; } = new();

        public override EventType Type => EventType.Update;
    }

    public sealed class Segment
    {
        public string Path { get; set; } = string.Empty;

        public string Value { get; set; } = string.Empty;

        public string ReferenceId { get; set; } = string.Empty;
    }
}
