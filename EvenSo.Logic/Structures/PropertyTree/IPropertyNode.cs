namespace EvenSo.Logic.Structures.PropertyTree
{
    public interface IPropertyNode : INode<IPropertyNode>, IChangeable
    {
        string Name { get; }
        object? Value { get; }
    }
}
