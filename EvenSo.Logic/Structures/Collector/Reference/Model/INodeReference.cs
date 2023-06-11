#region Usings

using EvenSo.Logic.Structures.Node;

#endregion

namespace EvenSo.Logic.Structures.Collector
{
    internal interface INodeReference
    {
        IObjectNode ReferenceNode { get; }

        IEnumerable<INode> ReferencedNodes { get; }
    }
}
