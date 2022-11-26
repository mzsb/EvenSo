using EvenSo.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenSo.Logic.Exceptions
{
    internal sealed  class NodeException : Exception
    {
        public INode? Node { get; }
        public NodeException(string? message = default, INode? node = default) : base(message) 
        { 
            Node = node; 
        }
    }
}
