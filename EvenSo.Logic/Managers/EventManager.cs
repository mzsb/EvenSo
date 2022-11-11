#region Usings

using EvenSo.Logic.Events;
using EvenSo.Logic.Model;
using Microsoft.Azure.Cosmos;

#endregion

namespace EvenSo.Logic.Managers
{
    internal sealed class EventManager
    {
        internal async Task CreateAsync(IIdentifiable item, Func<Create, Task> publish)
        {
            var j = new Create()
            {
                PK = new (item.ItemId),
                ItemPK = item.PartitionKey
            };

            await publish(j);
        }

        internal async Task DeleteAsync(IIdentifiable item, Func<Delete, Task> publish)
        {
            await publish(new Delete { PK = new (item.ItemId) });
        }

        internal async Task UpdateAsync(IIdentifiable item, Func<Update, Task> publish)
        {
            await publish(new Update { PK = new (item.ItemId) });
        }
    }
}
