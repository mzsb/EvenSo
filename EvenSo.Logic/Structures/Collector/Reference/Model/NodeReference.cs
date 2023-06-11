#region Usings

using EvenSo.Logic.Structures.Node;
using System.Diagnostics;

#endregion

namespace EvenSo.Logic.Structures.Collector
{
    [DebuggerDisplay("{EntityNode}")]
    internal sealed record NodeReference
    (
        IObjectNode ReferenceNode,
        IEnumerable<INode> ReferencedNodes
    ) : INodeReference;
}
