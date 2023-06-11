using EvenSo.Logic.Attributes;

namespace EvenSo.Client.Test.TestModel
{
    public class TestRoot
    {
        [Id]
        public string Key { get; set; } = "TestItemId";

        [PartitionKey]
        public string TestRootPartitionKey { get; set; } = "TestItemPK";

        //public object? TestNull { get; set; }

        public string TestString { get; set; } = "Test";

        //public int TestInt { get; set; } = 0;

        //public bool TestBool { get; set; } = false;

        //public Guid TestGuid { get; set; } = Guid.NewGuid();

        //public DateTime TestDateTime { get; set; } = DateTime.Now;

        //public decimal TestDecimal { get; set; } = 0.3m;

        //public TestChild TestChild { get; set; } = new();

        //public TestReferenceChild TestReferenceChild { get; set; } = new();

        //public bool[] TestArray { get; set; } = new[] { true, false };

        //public List<string?> TestPrimitiveList { get; set; } = new[] { null, "ok", "kak", "ok" }.ToList();

        //public Dictionary<int, object?> TestDictionary { get; set; } = new()
        //{
        //    [0] = new()
        //};

        //public List<TestBaseListItem?> TestList { get; set; } = new()
        //{
        //    new TestListItem { TestBaseListItemId = "1" },
        //    new TestListItem { TestBaseListItemId = "2" }
        //};
    }

    public class TestChild
    {
        public string TestChildId { get; set; } = "TestChildId";
    }

    public class TestReferenceChild
    {
        [Id]
        public string Id { get; set; } = "TestReferenceId";

        [PartitionKey]
        public string TestReferencedPK { get; set; } = "TestReferencePK";

        public List<TestChild> MyProperty { get; set; } = new()
        {
            new TestChild
            {
                TestChildId = "TestChildId1"
            },
              new TestChild
            {
                TestChildId = "TestChildId2"
            },
        };
    }

    public class TestBaseListItem
    {
        [Id]
        public string TestBaseListItemId { get; set; } = "TestBaseListItemId";

        //public string TestBaseListItemProperty { get; set; } = "TestBaseListItemProperty";
    }

    public class TestListItem : TestBaseListItem
    {
        [PartitionKey]
        public string TestListItemPK { get; set; } = "TestListItemPK";

        //public TestChild TestChild { get; set; } = new();
    }
}
