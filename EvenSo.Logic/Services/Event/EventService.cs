#region Usings

using EvenSo.Logic.Attributes;
using EvenSo.Logic.Model.Event;
using EvenSo.Logic.Structures.Collector;
using EvenSo.Logic.Structures.Node;
using EvenSo.Logic.Structures.Tree;
using EvenSo.Logic.Trackers;
using Microsoft.Azure.Cosmos;
using System.Collections.Immutable;
using System.Threading;

#endregion


namespace EvenSo.Logic.Services
{
    internal sealed class EventService : IEventService
    {
        private readonly Container _eventContainer;
        private readonly IObjectTracker _objectTracker;
        private readonly IChangeCollector _changeCollector;
        private readonly IReferenceCollector _referenceCollector;

        public EventService
        (
            Container eventContainer,
            IObjectTracker objectTracker,
            IChangeCollector changeCollector,
            IReferenceCollector referenceCollector
        )
        {
            ContainerService.Instance.Add(eventContainer, this);

            _eventContainer = eventContainer;
            _objectTracker = objectTracker;
            _changeCollector = changeCollector;
            _referenceCollector = referenceCollector;
        }

        public async Task<ItemResponse<CreateEvent>> CreateAsync
        (
            object entity,
            ItemRequestOptions? requestOptions = default,
            CancellationToken cancellationToken = default
        ) => await ExceptionIfNull
        (
            entity,           
            ifNotNull: async entity => await PublishAsync
            (
                entity.ToPropertyTree()
                      .ToCreateEvent(_referenceCollector),
                requestOptions,
                cancellationToken
            )
        );


        public async Task<ItemResponse<UpdateEvent>> UpdateAsync
        (
            object entity,  
            ItemRequestOptions? requestOptions = default,
            CancellationToken cancellationToken = default
        ) => await ExceptionIfNull
        (
            entity,
            ifNotNull: async entity => await PublishAsync
            (
                entity.ToPropertyTree()
                      .ToUpdateEvent(_changeCollector),
                requestOptions,
                cancellationToken
            )
        );

        public async Task<ItemResponse<DeleteEvent>> DeleteAsync
        (
            object entity, 
            ItemRequestOptions? requestOptions = default, 
            CancellationToken cancellationToken = default
        ) => await ExceptionIfNull
        (
            entity,
            ifNotNull: async entity => await PublishAsync
            (
                entity.ToPropertyTree()
                      .ToDeleteEvent(_referenceCollector),
                requestOptions,
                cancellationToken
            )
        );

        public void Track(object entity) => ExceptionIfNull
        (
            entity,
            ifNotNull: _objectTracker.Track
        );

        public void UnTrack(object entity) => ExceptionIfNull
        (
            entity,
            ifNotNull: _objectTracker.UnTrack
        );

        private T ExceptionIfNull<T>(object entity, Func<object, T> ifNotNull) =>
            entity is  not null ?
                ifNotNull(entity) :
                throw new Exception("Entity cannot be null!");

        private void ExceptionIfNull<T>(T entity, Action<T> ifNotNull)
        {
            if(entity is null) throw new Exception("Entity cannot be null!");

            ifNotNull(entity);
        }

        private async Task<ItemResponse<T>> PublishAsync<T>
        (
            T @event,
            ItemRequestOptions? requestOptions = null,
            CancellationToken cancellationToken = default
        ) where T : IEvent => await _eventContainer.CreateItemAsync
        (
            item: @event,
            partitionKey: @event.PartitionKey
                .ToCosmosPartitionKey(),
            requestOptions,
            cancellationToken
        );
    }
}
