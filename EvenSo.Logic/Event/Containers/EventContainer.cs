#region Usings

using System.Net;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

#endregion

namespace EvenSo.Events
{
    public sealed partial class EventContainer
    {
        private readonly Container _container;
        private readonly EventService _eventManager;

        internal EventContainer(Container container, EventService? eventManager = null)
        {
            _container = container;
            _eventManager = eventManager ?? new EventService();
        }

        public async Task CreateEventAsync<IdType>(
            object item,
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
            object item,
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
    }

    public static class EventContainers
    {
        public static EventContainer GetEventContainer(this CosmosClient cosmosClient, string databaseId, string? containerId = Constants._eventContainerId) 
        {
            cosmosClient.ClientOptions.Serializer = new CosmosJsonDotNetSerializer(new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ReferenceLoopHandling = ReferenceLoopHandling.Error,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy(),
                },
                Converters = new JsonConverter[]
                {
                    new StringEnumConverter()
                },
            });

            return new(cosmosClient.GetContainer(databaseId, containerId));
        }

        public static EventContainer GetEventContainer(this Database database, string databaseId) =>
            new(database.GetContainer(databaseId));
    }
}
