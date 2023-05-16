using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenSo.Logic.Structures.PropertyTree
{
    public interface IPropertyTree : ITree<IPropertyNode>
    {
        IEnumerable<IPropertyNode> ChangedNodes { get; }

        IEnumerable<IPropertyNode> Nodes { get; }
    }
}
