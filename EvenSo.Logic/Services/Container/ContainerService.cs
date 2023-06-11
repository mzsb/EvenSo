#region Usings

using Microsoft.Azure.Cosmos;
using System.Runtime.CompilerServices;

#endregion

namespace EvenSo.Logic.Services
{
    internal sealed class ContainerService
    {
        private readonly ConditionalWeakTable<Container, IEventService> _services = new();

        private ContainerService() { }

        static ContainerService() { }

        public static readonly ContainerService Instance = new();

        public void Add(Container container, IEventService eventService) =>
            _services.Add(container, eventService);

        public void Remove(Container container) =>
            _services.Remove(container);

        public bool TryGet(Container container, out IEventService? eventService) =>
            _services.TryGetValue(container, out eventService);
    }
}
