#region Usings

using EvenSo.Logic.Attributes;
using EvenSo.Logic.Model;
using EvenSo.Logic.Model.Event;
using EvenSo.Logic.Structures.Node;
using System.Collections.Immutable;

#endregion

namespace EvenSo.Logic.Structures.Collector
{
    internal static class ChangeCollectorHelper
    {
        internal static IReadOnlyDictionary<string, Change> ToChanges(this IEnumerable<INodeChange> nodeChanges) => 
            nodeChanges.ToImmutableDictionary
            (
                nodeChange => nodeChange.Node.GetPath(),
                nodeChange => new Change
                (
                    Value: nodeChange.Type is ElementRemoved ? null : nodeChange.Node.Value,
                    UpReference: nodeChange.ToReference(),
                    SubReferences: nodeChange.SubReferences.ToReferences(),
                    ChangeType: nodeChange.Type.ToChangeType()
                )
            );

        internal static Model.Event.ChangeType ToChangeType(this ChangeType changeType) => changeType switch
        {
            ValueChanged => Model.Event.ChangeType.ValueChanged,
            ElementAdded => Model.Event.ChangeType.ElementAdded,
            ElementRemoved => Model.Event.ChangeType.ElementRemoved,
            _ => throw new Exception(),
        };

        internal static Reference? ToReference(this INodeChange nodeChange) =>
        nodeChange.ReferenceNode is not null ?
            new
            (
                ReferenceId: nodeChange.ReferenceNode.Get<Id>().KeyValue,
                ReferencedPaths: nodeChange.Node.GetPath(till: nodeChange.ReferenceNode.Parent)
            ) :
            null;
    }
}
