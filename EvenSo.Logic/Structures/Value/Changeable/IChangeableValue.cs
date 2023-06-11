namespace EvenSo.Logic.Structures.Value
{
    internal interface IChangeableValue<T>
    {
        T? Old { get; }

        T? Actual { get; }

        bool IsChanged { get; }

        void Refresh();
    }
}
