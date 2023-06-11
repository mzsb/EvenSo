#region Usings

using EvenSo.Logic.Structures.Node;
using System.Diagnostics;

#endregion

namespace EvenSo.Logic.Structures.Collector
{
    [DebuggerDisplay("{Node}")]
    internal sealed record NodeChange
    (
        INode Node,
        ChangeType Type,
        IObjectNode? ReferenceNode,
        IEnumerable<INodeReference> SubReferences
    ): INodeChange;
}
