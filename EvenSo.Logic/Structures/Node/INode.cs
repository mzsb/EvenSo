#region Usings

using EvenSo.Logic.Structures.Collector;
using EvenSo.Logic.Structures.Visitor;

#endregion

namespace EvenSo.Logic.Structures.Node
{
    internal interface INode
    {
        string Key { get; }

        object? Value { get; }

        INode Parent { get; }

        IEnumerable<INode> Children { get; }

        INode this[string key] =>
            Children.SingleOrDefault(child => child.Key == key) 
            ?? NullNode.Instance;

        void Accept(INodeVisitor visitor);
    }
}
