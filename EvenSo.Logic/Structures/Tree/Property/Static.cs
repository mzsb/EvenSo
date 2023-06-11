#region Usings

using EvenSo.Logic.Model;
using EvenSo.Logic.Structures.Collector;
using EvenSo.Logic.Structures.Node;

#endregion

namespace EvenSo.Logic.Structures.Tree
{
    internal static class PropertyTreeHelper
    {
        internal static IPropertyTree ToPropertyTree(this object entity) =>
            new PropertyTree(entity);
        
        internal static IEnumerable<INodeChange> GetNodeChanges(this IPropertyTree propertyTree, IChangeCollector with) =>
           propertyTree.Root.GetNodeChanges(with);

        internal static IEnumerable<INodeReference> GetNodeReferences(this IPropertyTree propertyTree, IReferenceCollector with) =>
            propertyTree.Root.GetNodeReferences(with);

        internal static IEnumerable<Reference> GetReferences(this IPropertyTree propertyTree, IReferenceCollector with) => 
            propertyTree.GetNodeReferences(with)
                        .ToReferences();

    }
}
