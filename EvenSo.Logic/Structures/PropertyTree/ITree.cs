namespace EvenSo.Logic.Structures.PropertyTree
{
    public interface ITree<T> where T : INode<T>
    {
        T Root { get; }
    }
}
