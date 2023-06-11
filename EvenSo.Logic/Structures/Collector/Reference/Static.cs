#region Usings

using EvenSo.Logic.Attributes;
using EvenSo.Logic.Model;
using EvenSo.Logic.Structures.Node;
using System.Collections.Immutable;

#endregion

namespace EvenSo.Logic.Structures.Collector
{
    internal static class ReferenceCollectorHelper
    {
        internal static IEnumerable<Reference> ToReferences(this IEnumerable<INodeReference> nodeReferences) => nodeReferences
            .Select(subReference => subReference.ToReference())
            .ToImmutableArray();

        internal static Reference ToReference(this INodeReference nodeReference) => new
        (
            ReferenceId: nodeReference.ReferenceNode.Get<Id>().KeyValue,
            ReferencedPaths: nodeReference.ReferencedNodes
                .Select(referenceNode =>
                            referenceNode.GetPath(till: nodeReference.ReferenceNode.Parent))
                .ToArray()
        );
    }
}
