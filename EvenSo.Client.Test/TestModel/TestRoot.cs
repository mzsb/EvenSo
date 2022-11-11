using EvenSo.Logic.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenSo.Client.Test.TestModel
{
    [Item("ItemId", "Type")]
    public class TestRoot
    {
        public string ItemId { get; set; } 

        public string Type { get; set; } 

        public DateTime TestProperty { get; set; }

        public ReferencedItem ReferencedItem { get; set; } = new();

        public ICollection<ListItem> List { get; set; } = new List<ListItem>();

    }

    [Reference("ListItemId", "PartitionKey")]
    [ListItem("ListItemId")]
    public class ListItem
    {
        public string ListItemId { get; set; } 

        public string PartitionKey { get; set; }

        [Referenced]
        public bool Ref { get; set; } = false;
    }

    [Reference("ReferencedItemId", "PartitionKey")]
    public class ReferencedItem
    {
        public string ReferencedItemId { get; set; } = "testId";

        public string PartitionKey { get; set; } = "testPK";

        [Referenced]
        public int? ReferencedProperty { get; set; }

        public REFF MyProperty { get; set; } = new();
    }

    [Reference("REFFId", "REFFPartitionKey")]
    public class REFF
    {
        public string REFFId { get; set; } = "REFFId";

        public string REFFPartitionKey { get; set; } = "REFFPartitionKey";

        [Referenced]
        public List<int> PrimitveList { get; set; } = new List<int> { 1, 2 };
    }
}
