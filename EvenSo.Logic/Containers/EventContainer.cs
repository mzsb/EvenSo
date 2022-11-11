#region Usings

using EvenSo.Logic.Extensions;
using System.Net;
using EvenSo.Logic.Managers;
using Microsoft.Azure.Cosmos;
using EvenSo.Logic.Builders;
using EvenSo.Logic.Model;
using EvenSo.Logic.Events;

#endregion

namespace EvenSo.Logic.Containers
{
    public sealed partial class EventContainer
    {
        private readonly Container _container;
        private readonly EventManager _eventManager;

        internal EventContainer(Container container, EventManager? eventManager = null)
        {
            _container = container;
            _eventManager = eventManager ?? new EventManager();
        }

        public async Task CreateEventAsync<IdType>(
            IIdentifiable item,
            ItemRequestOptions? requestOptions = null,
            CancellationToken cancellationToken = default) => await item.IsNotNull(async () =>

            await _eventManager.CreateAsync(item, async createEvent =>
            {
                var response = await CreateItemAsync(createEvent, createEvent.PK, requestOptions, cancellationToken);

                if (response.StatusCode != HttpStatusCode.Created)
                {
                    throw new System.Exception($"Create event publish error: {response.StatusCode}");
                }
            })

        );

        public async Task DeleteEventAsync<IdType>(
            IIdentifiable item,
            ItemRequestOptions? requestOptions = null,
            CancellationToken cancellationToken = default) => await item.IsNotNull(async () =>

            await _eventManager.DeleteAsync(item, async deleteEvent =>
            {
                var response = await CreateItemAsync(deleteEvent, deleteEvent.PK, requestOptions, cancellationToken);

                if (response.StatusCode != HttpStatusCode.Created)
                {
                    throw new System.Exception($"Delete event publish error: {response.StatusCode}");
                }
            })
        );

        //public async Task UpdateEventAsync<T>(
        //    IUpdateBuilder<T> updateBuilder,
        //    ItemRequestOptions? requestOptions = null,
        //    CancellationToken cancellationToken = default)
        //{

        //    _ = 0;

        //}
    }
}
