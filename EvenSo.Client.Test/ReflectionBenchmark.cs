using BenchmarkDotNet.Attributes;
using EvenSo.Client.Test.Model;
using EvenSo.Logic.Extensions;
using EvenSo.Nodes;

namespace EvenSo.Client.Test
{

    [MemoryDiagnoser]
    public class ReflectionBenchmark
    {
        public readonly PropertyTest1 _item = new();

        [Benchmark]
        public void SingletonTest2()
        {
            foreach (var item in _item.GetNodess())
            {
                var value = item.Value;
            }
        }

        [Benchmark]
        public void SingletonTest1()
        {
            foreach (var item in _item.GetNodes())
            {
                var value = item.Value;
            }
        }
    }
}
