using BenchmarkDotNet.Attributes;
using EvenSo.Caches;
using EvenSo.Client.Test.Model;
using EvenSo.Client.Test.TestModel;
using EvenSo.PropertyTrees;

namespace EvenSo.Client.Test
{

    [MemoryDiagnoser]
    public class TypeBenchmark
    {
        //[ParamsSource(nameof(TestValues))]
        //public object Test { get; set; }

        //public IEnumerable<object> TestValues => new object[]
        //{
        //    new TestRoot(),
        //    new PropertyTest6(),
        //};

        //[Benchmark]
        //public void Benchmark()
        //{
        //    foreach (var item in Test.ToNodes())
        //    {
        //        var value = item.IsChanged();
        //    };
        //}
    }
}
