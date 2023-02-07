#region Usings

using Microsoft.Azure.Cosmos;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

#endregion

namespace EvenSo.Events
{
    internal abstract class Event
    {
        internal Guid Id { get; } = Guid.NewGuid();

        internal PartitionKey? PK { get; init; }

        internal PartitionKey? ItemPK { get; init; }

        internal DateTime CreationDate { get; } = DateTime.UtcNow;

        [JsonConverter(typeof(StringEnumConverter))]
        internal virtual EventType Type { get; }
    }
}
