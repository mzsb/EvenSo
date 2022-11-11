using EvenSo.Logic.Attributes;
using EvenSo.Logic.Model;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenSo.Client.Test.Model
{
    [Item(id: "IdHolder/MoreIdHolder/Id", partitionKey: "IdHolder/PartitionKey")]
    public abstract class WikidataEntity
    {
        public IdHolder IdHolder { get; set; } = new();

        public ICollection<Label> Labels { get; set; } = new List<Label>();
    }

    [Item(id: "Id", partitionKey: "Value")]
    public class IdHolder
    {
        public string Id { get; set; } = "id";
        public string Value { get; set; } = "value";
        public MoreIdHolder MoreIdHolder { get; set; } = new();

        public string PartitionKey { get; set; } = "test partitionKey";
    }

    public class MoreIdHolder
    {
        public string Id { get; set; } = "test id";
    }
}
