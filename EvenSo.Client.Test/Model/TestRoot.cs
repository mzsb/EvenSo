using EvenSo.Caches;


namespace EvenSo.Client.Test.TestModel
{
    public class TestRoot
    {
        //[Key(KeyType.Id)]
        //public string Key { get; set; } = "TestItemId";

        //[Key(KeyType.PartitionKey)]
        //public string Type { get; set; } = "TestItemPK";

        //public object? TestNull { get; set; }

        //public string TestString { get; set; } = "Test";

        //public int TestInt { get; set; } = 0;

        //public bool TestBool { get; set; } = false;

        //public Guid TestGuid { get; set; } = Guid.NewGuid();

        //public DateTime TestDateTime { get; set; } = DateTime.Now;

        //public decimal TestDecimal { get; set; } = 0.3m;

        //public TestChild TestChild { get; set; } = new();

        //public TestReferenceChild TestReferenceChild { get; set; } = new();

        public bool[] TestArray { get; set; } = new[] { true, false };

        public List<int> TestPrimitiveList { get; set; } = new[] { 2, 0, 2, 2 }.ToList();

        public Dictionary<int, object?> TestDictionary { get; set; } = new()
        {
            [0] = new()
        };

        public List<TestBaseListItem> TestList { get; set; } = new()
        {
            new TestBaseListItem(),
            new TestListItem { TestBaseListItemId = "TestListItemId" },
        };
    }

    public class TestChild
    {
        public string TestChildProperty { get; set; } = "TestChildProperty";
    }

    public class TestReferenceChild
    {
        [Key(KeyType.Id)]
        public string TestReferencedId { get; set; } = "TestReferenceId";

        [Key(KeyType.PartitionKey)]
        public string TestReferencedPK { get; set; } = "TestReferencePK";
        //public int TestReferencedProperty { get; set; } = 3;
    }

    public class TestBaseListItem
    {
        [Key(KeyType.Id)]
        public string TestBaseListItemId { get; set; } = "TestBaseListItemId";

        public string TestBaseListItemProperty { get; set; } = "TestBaseListItemProperty";
    }

    public class TestListItem : TestBaseListItem
    {

        [Key(KeyType.PartitionKey)]
        public string TestListItemPK { get; set; } = "TestListItemPK";
    }
}
