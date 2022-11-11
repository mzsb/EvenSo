using EvenSo.Logic.Enums;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace EvenSo.Logic.Events
{
    public abstract class Event
    {
        public Guid Id { get; } = Guid.NewGuid();

        public PartitionKey? PK { get; init; }

        public PartitionKey? ItemPK { get; init; }

        public DateTime CreationDate { get; } = DateTime.UtcNow;

        [JsonConverter(typeof(StringEnumConverter))]
        public virtual EventType Type { get; }
    }
}
