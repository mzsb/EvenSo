using EvenSo.Client.Test.TestModel;
using EvenSo.Logic.Structures.Tree;

namespace EvenSo.Test
{
    public class PropertyTest
    {
        private readonly TestRoot _test = new();

        [Fact]
        public void TestString()
        {
            var propertyTree = _test.ToPropertyTree();

            _test.TestString = "test1";

            //var changes = propertyTree.Changes;

            //Assert.NotEmpty(changes);
        }
    }
}