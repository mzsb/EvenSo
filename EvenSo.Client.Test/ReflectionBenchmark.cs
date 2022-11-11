using BenchmarkDotNet.Attributes;
using EvenSo.Client.Test.Model;
using EvenSo.Logic.Attributes;
using EvenSo.Logic.Extensions;
using System.Reflection;

namespace EvenSo.Client.Test
{
    [MemoryDiagnoser]
    public class ReflectionBenchmark
    {
        public readonly PropertyTest _label = new();

        [Benchmark]
        public void SimpleLoop()
        {
            foreach (var item in _label.GetType().GetProperties())
            {
                var value = item.GetValue(_label);
            }

            //if (type.GetCustomAttribute<IdentifiableAttribute>(inherit: true) is { } identifiableAttribute)
            //{
            //    if (identifiableAttribute is not null)
            //    {
            //        object? value = _label;
            //        foreach (var idPath in identifiableAttribute.Id.Split('/'))
            //        {
            //            value = value.GetType().GetProperty(idPath).GetValue(value);
            //        }

            //        var id = value;

            //        value = _label;
            //        foreach (var idPath in identifiableAttribute.PartitonKey.Split('/'))
            //        {
            //            value = value.GetType().GetProperty(idPath).GetValue(value);
            //        }

            //        var partitionkey = value;
            //    }
            //}
        }

        [Benchmark]
        public void CompiledLoop()
        {
            foreach (var item in _label.GetProperties())
            {
                var value = item.GetValue(_label);
            }
            //var id = _label.GetId();
            //var partitionkey = _label.GetPartitionKey();
        }

        //[Benchmark]
        //public void CompileddLoop()
        //{
        //    foreach (var property in _label.GetType().GetCachedProperties())
        //    {
        //        foreach (var customAttribute in property.CustomAttributes)
        //        {
        //            if (customAttribute.AttributeType == typeof(Referenced))
        //            {
        //                var t = customAttribute.ConstructorArguments[0].Value;
        //                break;
        //            }
        //        }
        //    }
        //}
    }
}
