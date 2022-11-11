using Microsoft.Azure.Cosmos;

namespace EvenSo.Logic.Model
{
    public interface IIdentifiable
    {
        public string ItemId { get; }

        public PartitionKey PartitionKey { get; }
    }
}
