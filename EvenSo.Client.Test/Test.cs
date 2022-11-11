using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EvenSo.Client.Test
{
    public class Test
    {
        public Ids Ids { get; set; } = new Ids { Id = "id", PartitionKey = "partitionKey" };
    }

    public struct Ids 
    {
        public string Id { get; init; }
        public string PartitionKey { get; init; }
    }
}
