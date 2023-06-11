#region Usings

using EvenSo.Logic.Attributes;
using EvenSo.Logic.Structures.Collector;
using EvenSo.Logic.Structures.Tree;
using Microsoft.Azure.Cosmos.Serialization.HybridRow.Schemas;
using System.Collections.Immutable;

#endregion

namespace EvenSo.Logic.Model.Event
{
    internal static class EventHelper
    {
        public static CreateEvent ToCreateEvent(this IPropertyTree propertyTree, IReferenceCollector with) => new
        (
            Id: Guid.NewGuid(),
            PartitionKey: propertyTree.Root.Get<Id>().KeyValue,
            CreationDate: DateTime.Now,
            EntityKeys: propertyTree.Root.Keys
                .ToImmutableDictionary(key => key.KeyType.Name, key => key.KeyValue),
            EventType: EventType.Create,
            InitialValue: propertyTree.Root.Value,
            SubReferences: propertyTree
                .GetNodeReferences(with)
                .ToReferences()
        );

        public static UpdateEvent ToUpdateEvent(this IPropertyTree propertyTree, IChangeCollector with) => new
        (
            Id: Guid.NewGuid(),
            PartitionKey: propertyTree.Root.Get<Id>().KeyValue,
            CreationDate: DateTime.Now,
            EntityKeys: propertyTree.Root.Keys
                .ToImmutableDictionary(key => key.KeyType.Name, key => key.KeyValue),
            EventType: EventType.Update,
            Changes: propertyTree
                .GetNodeChanges(with)
                .ToChanges()
        );

        public static DeleteEvent ToDeleteEvent(this IPropertyTree propertyTree, IReferenceCollector with) => new             
        (
            Id: Guid.NewGuid(),
            PartitionKey: propertyTree.Root.Get<Id>().KeyValue,
            CreationDate: DateTime.Now,
            EntityKeys: propertyTree.Root.Keys
                .ToImmutableDictionary(key => key.KeyType.Name, key => key.KeyValue),
            EventType: EventType.Delete,
            SubReferences: propertyTree
                .GetNodeReferences(with)
                .ToReferences()
        );
    }
}
