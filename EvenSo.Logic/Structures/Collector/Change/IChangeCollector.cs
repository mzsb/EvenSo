#region Usings

using EvenSo.Logic.Structures.Visitor;

#endregion

namespace EvenSo.Logic.Structures.Collector
{
    internal interface IChangeCollector : ICollector<INodeChange>, INodeVisitor  { }
}
