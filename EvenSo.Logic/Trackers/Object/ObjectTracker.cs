#region Usings

using EvenSo.Logic.Attributes;
using EvenSo.Logic.Model.Event;
using EvenSo.Logic.Structures.Collector;
using EvenSo.Logic.Structures.Node;
using EvenSo.Logic.Structures.Tree;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

#endregion

namespace EvenSo.Logic.Trackers
{
    internal sealed class ObjectTracker : IObjectTracker
    {
        private ConditionalWeakTable<object, IPropertyTree> _track { get; } = new();

        public void Track(object entity) => 
            _track.AddOrUpdate(entity, entity.ToPropertyTree());

        public bool UnTrack(object entity) =>
            _track.Remove(entity);

        public IPropertyTree GetPropertyTree(object entity) =>
            _track.TryGetValue(entity, out var propertyTree) ? 
                propertyTree :
                throw new Exception($"{entity} was not tracked!");
    }
}
