namespace EvenSo.Logic.Model.Event
{
    public sealed record Change
    (
        object? Value,
        Reference? UpReference,
        IEnumerable<Reference> SubReferences,
        ChangeType ChangeType
    );
}
