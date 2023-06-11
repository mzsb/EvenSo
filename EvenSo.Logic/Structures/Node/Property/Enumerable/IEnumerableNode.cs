namespace EvenSo.Logic.Structures.Node
{
    internal interface IEnumerableNode : IPropertyNode<IEnumerable<object?>>, IEnumerable<object?>
    {
        (IEnumerable<INode> Removed, IEnumerable<INode> Added) UpdateChildren();
    }
}
