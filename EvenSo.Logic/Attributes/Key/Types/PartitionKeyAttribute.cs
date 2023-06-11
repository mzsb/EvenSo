namespace EvenSo.Logic.Attributes
{
    public sealed class PartitionKey : KeyAttribute
    {
        public PartitionKey(Type? of = null) : base(of) { }
    }
}
