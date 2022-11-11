#region Usings

using EvenSo.Logic.Containers;
using Microsoft.Azure.Cosmos;
using OriginalCosmosClient = Microsoft.Azure.Cosmos.CosmosClient;

#endregion

namespace EvenSo.Logic.Extensions
{
    public static class Cosmos
    {
        public static EventContainer GetEventContainer(this OriginalCosmosClient cosmosClient, string databaseId, string? containerId = Constants._eventContainerId) => 
            new(cosmosClient.GetContainer(databaseId, containerId));

        public static EventContainer GetEventContainer(this Database database, string databaseId) =>
            new(database.GetContainer(databaseId));
    }
}
