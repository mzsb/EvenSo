#region Usings

using EvenSo.Logic.Model.Event;
using Microsoft.Azure.Cosmos;

#endregion


namespace EvenSo.Logic.Services
{
    public interface IEventService
    {
        Task<ItemResponse<CreateEvent>> CreateAsync(object entity, ItemRequestOptions? requestOptions = default, CancellationToken cancellationToken = default);

        Task<ItemResponse<UpdateEvent>> UpdateAsync(object entity, ItemRequestOptions? requestOptions = default, CancellationToken cancellationToken = default);

        Task<ItemResponse<DeleteEvent>> DeleteAsync(object entity, ItemRequestOptions? requestOptions = default, CancellationToken cancellationToken = default);

        void Track(object entity);

        void UnTrack(object entity);
    }
}
