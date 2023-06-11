#region Usings

using EvenSo.Logic.Structures.Visitor;

#endregion

namespace EvenSo.Logic.Structures.Collector
{
    internal interface IReferenceCollector : ICollector<INodeReference>, INodeVisitor { }
}
