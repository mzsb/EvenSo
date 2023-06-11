#region Usings

using EvenSo.Logic.Structures.Node;

#endregion

namespace EvenSo.Logic.Structures.Tree
{
    internal interface IPropertyTree : IEnumerable<INode>
    {
        IObjectNode Root { get; }

        IEnumerable<INode> Nodes { get; }

        INode this[string key] => Root[key] 
            ?? NullNode.Instance;
    }
}
