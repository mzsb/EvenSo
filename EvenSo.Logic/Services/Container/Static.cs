#region Usings

using EvenSo.Logic.Model.Event;
using Microsoft.Azure.Cosmos;

#endregion

namespace EvenSo.Logic.Services
{
    public static class ContainerServiceHelper
    {
        public static async Task<ItemResponse<CreateEvent>> CreateItemEventAsync
        (
            this Container container,
            object item,
            ItemRequestOptions? requestOptions = default,
            CancellationToken cancellationToken = default
        )
        {
            if(ContainerService.Instance.TryGet(container, out IEventService? eventService) && 
               eventService is not null)
            {
                return await eventService.CreateAsync(item, requestOptions, cancellationToken);
            }

            throw new Exception();
        }

        public static async Task<ItemResponse<UpdateEvent>> UpdateItemEventAsync
        (
            this Container container,
            object item,
            ItemRequestOptions? requestOptions = default,
            CancellationToken cancellationToken = default
        )
        {
            if (ContainerService.Instance.TryGet(container, out IEventService? eventService) &&
               eventService is not null)
            {
                return await eventService.UpdateAsync(item, requestOptions, cancellationToken);
            }

            throw new Exception();
        }

        public static async Task<ItemResponse<DeleteEvent>> DeleteItemEventAsync
        (
            this Container container,
            object item,
            ItemRequestOptions? requestOptions = default,
            CancellationToken cancellationToken = default
        )
        {
            if (ContainerService.Instance.TryGet(container, out IEventService? eventService) &&
               eventService is not null)
            {
                return await eventService.DeleteAsync(item, requestOptions, cancellationToken);
            }

            throw new Exception();
        }

        public static void Track
        (
            this Container container,
            object item
        )
        {
            if (ContainerService.Instance.TryGet(container, out IEventService? eventService) &&
                eventService is not null)
            {
                eventService.Track(item);
            }
        }
    }
}
