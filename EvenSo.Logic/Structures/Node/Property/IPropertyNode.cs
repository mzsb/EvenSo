#region Usings

using EvenSo.Logic.Structures.Value;

#endregion

namespace EvenSo.Logic.Structures.Node
{
    internal interface IPropertyNode<T> : INode
    {
        string INode.Key => Name;

        object? INode.Value => Value.Actual;

        string Name { get; }

        new IChangeableValue<T> Value { get; }

        Type? ReferenceType { get; }
    }
}
