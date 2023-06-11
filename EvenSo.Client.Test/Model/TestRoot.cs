using EvenSo.Logic.Attributes;
using EvenSo.Logic.Attributes.Reference;

namespace EvenSo.Client.Test.TestModel
{
    public class TestRoot
    {
        [Id]
        public string Key { get; set; } = "TestItemId";

        [PartitionKey]
        public string TestRootPartitionKey { get; set; } = "TestItemPK";

        public object? TestNull { get; set; }

        public string TestString { get; set; } = "Test1";

        public int TestInt { get; set; } = 0;

        public bool TestBool { get; set; } = false;

        public Guid TestGuid { get; set; } = Guid.NewGuid();

        public DateTime TestDateTime { get; set; } = DateTime.Now;

        public decimal TestDecimal { get; set; } = 0.3m;

        public TestChild TestChild { get; set; } = new();

        public TestReferenceChild TestReferenceChild { get; set; } = new();

        public TestReferenceChild TestReferenceChild2 { get; set; } = new();

        public bool[] TestArray { get; set; } = new[] { true, false };

        public List<string?> TestPrimitiveList { get; set; } = new[] { null, "test1" }.ToList();

        public Dictionary<int, object?> TestDictionary { get; set; } = new()
        {
            [0] = new()
        };

        public List<TestBaseListItem?> TestList { get; set; } = new()
        {
            new TestListItem { TestBaseListItemId = "1" },
            new TestListItem { TestBaseListItemId = "2" }
        };
    }

    public class TestChild
    {
        [Id]
        public string TestChildId { get; set; } = "TestChildId";

        public string TestChildPK { get; set; } = "TestChildPK";

        [Reference(of: typeof(TestReferenceChild))]
        public string TestChildProperty { get; set; } = "TestChildProperty";
    }

    public class TestReferenceChild
    {
        [Id]
        public string TestReferenceChildId { get; set; } = "TestReferenceId";

        [PartitionKey]
        public string TestReferenceChildPK { get; set; } = "TestReferencePK";

        public string TestReferenceChildProperty { get; set; } = "TestReferenceChildProperty";

        public List<TestChild> TestReferenceChildList { get; set; } = new()
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

        public string TestBaseListItemProperty { get; set; } = "TestBaseListItemProperty";
    }

    public class TestListItem : TestBaseListItem
    {
        [PartitionKey]
        public string TestListItemPK { get; set; } = "TestListItemPK";

        public TestChild TestChild { get; set; } = new();
    }
}
