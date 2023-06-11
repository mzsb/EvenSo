#region Usings

using EvenSo.Logic.Model.Event;
using EvenSo.Logic.Services;
using EvenSo.Logic.Structures.Collector;
using EvenSo.Logic.Trackers;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

#endregion

namespace EvenSo.Logic.Configuration
{
    public static class Services
    {
        public static IHostBuilder ConfigureEvenSo
        (
            this IHostBuilder hostBuilder,
            Container eventContainer
        ) => hostBuilder.ConfigureServices((context, services) =>
        {
            services.AddSingleton(_ => eventContainer);
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IObjectTracker, ObjectTracker>();
            services.AddTransient<IReferenceCollector, ReferenceCollector>();
            services.AddTransient<IChangeCollector, ChangeCollector>();
        });
    }
}
