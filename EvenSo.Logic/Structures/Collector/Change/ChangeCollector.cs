#region Usings

using EvenSo.Logic.Structures.Node;
using System.Collections.Immutable;
using System.Diagnostics;

#endregion

namespace EvenSo.Logic.Structures.Collector
{
    [DebuggerDisplay("{Changes}")]
    internal sealed class ChangeCollector : IChangeCollector
    {
        private readonly IReferenceCollector _referenceCollector;

        private readonly ICollection<INodeChange> _changes = new List<INodeChange>();

        public ChangeCollector(IReferenceCollector referenceCollector) 
        {
            _referenceCollector = referenceCollector;
        }

        public IEnumerable<INodeChange> Collection
        {
            get
            {
                var collection = _changes.ToImmutableArray();
                _changes.Clear();
                return collection;
            }
        }

        public void Visit(IPrimitiveNode primitiveNode)
        {
            primitiveNode.Value.Refresh();

            if (primitiveNode.Value.IsChanged)
            {
                _changes.Add(primitiveNode.ToNodeChange
                (
                    type: ValueChanged, 
                    entityNode: primitiveNode.GetReferenceNode()
                ));
            }
        }

        public void Visit(IKeyNode keyNode) => Visit(keyNode as IPrimitiveNode);

        public void Visit(IObjectNode objectNode)
        {
            objectNode.Value.Refresh();

            if (objectNode.Value.IsChanged)
            {
                IEnumerable<INodeReference> subReferences;
                if (objectNode.Value.Actual is null)
                {
                    subReferences = objectNode.GetNodeReferences(with: _referenceCollector);
                    objectNode.UpdateChildren();
                }
                else
                {
                    objectNode.UpdateChildren();
                    subReferences = objectNode.GetNodeReferences(with: _referenceCollector);
                }

                _changes.Add(objectNode.ToNodeChange
                (
                    type: ValueChanged, 
                    entityNode: objectNode.GetReferenceNode(), 
                    subReferences: subReferences
                ));
            }
        }

        public void Visit(IEnumerableNode enumerableNode)
        {
            enumerableNode.Value.Refresh();

            if (enumerableNode.Value.IsChanged)
            {
                var (removed, added) = enumerableNode.UpdateChildren();

                if(enumerableNode.Value.Old is { } old &&
                   removed.Count() == old.Count() &&
                   !added.Any())
                {
                    _changes.Add(enumerableNode.ToNodeChange
                    (
                        type: ValueChanged,
                        entityNode: enumerableNode.GetReferenceNode(),
                        subReferences: removed.SelectMany
                        (
                            removedChild =>
                                removedChild.GetNodeReferences(with: _referenceCollector)
                        )
                    ));

                    return;
                }

                if(!removed.Any() && added.Any())
                {
                    _changes.Add(enumerableNode.ToNodeChange
                    (
                        type: ValueChanged,
                        entityNode: enumerableNode.GetReferenceNode(),
                        subReferences: added.SelectMany
                        (
                            addedChild =>
                                addedChild.GetNodeReferences(with: _referenceCollector)
                        )
                    ));

                    return;
                }

                foreach (var removedChild in removed)
                {
                    _changes.Add(removedChild.ToNodeChange
                    (
                        type: ElementRemoved,
                        entityNode: enumerableNode.GetReferenceNode(),
                        subReferences: removedChild.GetNodeReferences(with: _referenceCollector)
                    ));
                }

                foreach (var addedChild in added)
                {
                    _changes.Add(addedChild.ToNodeChange
                    (
                        type: ElementAdded,
                        entityNode: enumerableNode.GetReferenceNode(),
                        subReferences: addedChild.GetNodeReferences(with: _referenceCollector)
                    ));
                }
            }
        }
    }
}
