#region Using

using EvenSo.Logic.Structures.Node;

#endregion

namespace EvenSo.Logic.Structures.Visitor
{
    internal interface INodeVisitor
    {
        void Visit(IPrimitiveNode primitiveNode);

        void Visit(IKeyNode keyNode);

        void Visit(IObjectNode objectNode);

        void Visit(IEnumerableNode enumerableNode);
    }
}
