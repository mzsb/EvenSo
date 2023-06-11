namespace EvenSo.Logic.Model
{
    public sealed record Reference
    (
        object ReferenceId,
        params string[] ReferencedPaths
    );
}
