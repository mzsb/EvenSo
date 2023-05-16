#region Usings

using EvenSo.Caches;
using EvenSo.Logic.Structures.PropertyTree;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

#endregion

namespace EvenSo.PropertyTrees
{
    [DebuggerDisplay("{Root}")]
    public class PropertyTree : IPropertyTree
    {
        public PropertyTree(object item) => Root = 
            NodeFactory.Create(item);

        public IPropertyNode Root { get; }

        public IEnumerable<IPropertyNode> ChangedNodes => Nodes.Where(node => node.Changes.Any()).ToArray();

        public IEnumerable<IPropertyNode> Nodes
        {
            get
            {
                var nodeStack = new Stack<IPropertyNode>(new[] { Root });
                while (nodeStack.TryPop(out var node))
                {
                    yield return node;

                    foreach (var newNode in node.Children)
                    {
                        nodeStack.Push(newNode);
                    }
                }
            }
        }
    }
}
