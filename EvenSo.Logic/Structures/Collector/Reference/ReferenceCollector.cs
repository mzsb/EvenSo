#region Usings

using EvenSo.Logic.Structures.Node;
using System.Collections.Immutable;

#endregion

namespace EvenSo.Logic.Structures.Collector
{
    internal class ReferenceCollector : IReferenceCollector
    {
        private readonly IDictionary<IObjectNode, ICollection<INode>> _references = new Dictionary<IObjectNode, ICollection<INode>>();

        public IEnumerable<INodeReference> Collection
        {
            get
            {
                var collection = _references
                .Select(keyValue => 
                    new NodeReference(keyValue.Key, keyValue.Value.ToImmutableArray()))
                .ToImmutableArray();

                _references.Clear();
                return collection;
            }
        }

        public void Visit(IPrimitiveNode primitiveNode) =>
            CollectReferencedNode(primitiveNode);

        public void Visit(IKeyNode keyNode) =>
            CollectReferencedNode(keyNode);

        public void Visit(IObjectNode objectNode) =>
            CollectReferencedNode(objectNode);

        public void Visit(IEnumerableNode enumerableNode) =>
            CollectReferencedNode(enumerableNode);

        private void CollectReferencedNode<T>(IPropertyNode<T> referencedNode)
        {
            if(referencedNode.GetReferenceNode() is IObjectNode referenceNode)
            {
                _references.AddElement(referenceNode, referencedNode);
            }
        }
    }
}
