#region Usings

using EvenSo.Logic.Attributes;
using EvenSo.Logic.Structures.Collector;
using EvenSo.Logic.Structures.Node;
using System.Collections;
using System.Diagnostics;

#endregion

namespace EvenSo.Logic.Structures.Tree
{
    [DebuggerDisplay("{Root}")]
    internal sealed class PropertyTree : IPropertyTree
    {
        internal PropertyTree(object entity)
        {
            if (entity is null) throw new Exception();

            Root = new ObjectNode
            (
                value: entity, 
                name: entity.GetType().Name, 
                parent: NullNode.Instance
            ) is var root &&
            root.Has<Id>() &&
            root.Has<PartitionKey>() ? 
            root : 
            throw new Exception();
        }

        public IEnumerator<INode> GetEnumerator() => Nodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IObjectNode Root { get; }

        public IEnumerable<INode> Nodes => Root
            .GetSubNodes()
            .Prepend(Root);
    }
}
