#region Usings

using BenchmarkDotNet.Attributes;
using EvenSo.Client.Test.TestModel;
using EvenSo.Logic.Structures.Collector;
using EvenSo.Logic.Structures.Tree;

#endregion

namespace EvenSo.Client.Test
{

    [MemoryDiagnoser]
    public class TypeBenchmark
    {
        public TestRoot Test { get; set; } = new();
    }
}
