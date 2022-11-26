#region Usings

using EvenSo.Keys;
using EvenSo.Logic.Extensions;
using System.Collections;

#endregion

namespace EvenSo.Nodes
{
    public enum NodeType
    {
        Root = 1,
        Primitive = 2,
        Enumerable = 4,
        Element = 8,

        PrimitiveEnumerable = Primitive | Enumerable
    }
}
