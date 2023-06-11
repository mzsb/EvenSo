#region Usings

using EvenSo.Client.Test.TestModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EvenSo.Logic.Configuration;
using Microsoft.Azure.Cosmos;
using EvenSo.Logic.Services;
using Microsoft.Azure.Cosmos.Fluent;
using Newtonsoft.Json.Linq;

#endregion

#if RELEASE

BenchmarkRunner.Run<TypeBenchmark>();

#elif DEBUG

var accountEndpoint = string.Empty;
var authKey = string.Empty;

var cosmosClient = new CosmosClientBuilder(accountEndpoint, authKey)
    .WithSerializerOptions(new CosmosSerializationOptions 
    {
        PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase 
    })
    .Build();

var container = cosmosClient.GetDatabase("test-database").GetContainer("test-container");

using (var serviceScope = Host
    .CreateDefaultBuilder(args)
    .ConfigureEvenSo(eventContainer: container)
    .Build().Services
    .CreateScope())
{
    if (serviceScope.ServiceProvider.GetService<IEventService>() is 
        IEventService eventService)
    {
        var test = new TestRoot();

        await container.CreateItemEventAsync(test);

        container.Track(test);

        test.TestString = "Test2";

        await container.UpdateItemEventAsync(test);

        await container.DeleteItemEventAsync(test);
    }
}

#endif



