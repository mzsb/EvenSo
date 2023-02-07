namespace EvenSo.Events
{
    internal sealed class EventService
    {
        internal async Task CreateAsync(object item, Func<Create, Task> publish)
        {
            var j = new Create()
            {
                //PK = new (item.ItemId),
                //ItemPK = item.PartitionKey
            };

            await publish(j);
        }

        internal async Task DeleteAsync(object item, Func<Delete, Task> publish)
        {
            await publish(new Delete { /*PK = new (item.ItemId)*/ });
        }

        internal async Task UpdateAsync(object item, Func<Update, Task> publish)
        {
            await publish(new Update { /*PK = new (item.ItemId)*/ });
        }
    }
}
