#region Usings

using EvenSo.Logic.Structures.Collector;
using System.Text;

#endregion

namespace EvenSo.Logic.Structures.Node
{
    internal static class NodeHelper
    {
        internal static INodeChange ToNodeChange
        (
            this INode node,
            ChangeType type,
            IObjectNode? entityNode = null,
            IEnumerable<INodeReference>? subReferences = null
        ) => new NodeChange(node, type, entityNode, subReferences ?? Enumerable.Empty<INodeReference>());

        private static StringBuilder _pathBuilder = new();

        internal static string GetPath(this INode node, INode? till = null)
        {
            till ??= NullNode.Instance;

            _pathBuilder = _pathBuilder.Clear();

            do
            {
                _pathBuilder
                    .Insert(0, node.Key.ToCamelCase())
                    .Insert(0, '/');

                node = node.Parent;

            } while (node.Parent != till);

            return _pathBuilder.ToString();
        }

        internal static bool IsRoot(this INode node) =>
            node.Parent == NullNode.Instance;

        internal static IEnumerable<INode> GetSubNodes(this INode root)
        {
            var nodeStack = new Stack<INode>(root.Children);
            while(nodeStack.TryPop(out var node))
            {          
                yield return node;
                foreach (var child in node.Children)
                {
                    nodeStack.Push(child);
                }
            }
        }

        internal static IEnumerable<INode> GetBranch(this INode node)
        {
            while (!node.IsRoot())
            {
                yield return node;
                node = node.Parent;
            }
        }

        internal static IEnumerable<INodeChange> GetNodeChanges(this INode node, IChangeCollector with)
        {
            node.Accept(with);
            return with.Collection;
        }

        internal static IEnumerable<INodeReference> GetNodeReferences(this INode node, IReferenceCollector with)
        {
            node.Accept(with);
            return with.Collection;
        }

        internal static IObjectNode? GetReferenceNode<T>(this IPropertyNode<T> node) =>
            node.ReferenceType is not null ?
                node.GetBranch()
                    .FirstOrDefault
                    (
                        branchNode =>
                            branchNode is IObjectNode objectNode &&
                            objectNode.ObjectType == node.ReferenceType
                    ) as IObjectNode :
                null;
    }
}
