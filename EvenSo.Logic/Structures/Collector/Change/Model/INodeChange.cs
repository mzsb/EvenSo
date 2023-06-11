#region Usings

using EvenSo.Logic.Structures.Node;
using System.Collections.Immutable;

#endregion

namespace EvenSo.Logic.Structures.Collector
{
    internal interface INodeChange
    {
        INode Node { get; }

        ChangeType Type { get; }

        IObjectNode? ReferenceNode { get; }

        IEnumerable<INodeReference> SubReferences { get; }
    }
}
