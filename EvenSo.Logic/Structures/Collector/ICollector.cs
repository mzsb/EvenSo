namespace EvenSo.Logic.Structures.Collector
{
    internal interface ICollector<T>
    {
        IEnumerable<T> Collection { get; }
    }
}
