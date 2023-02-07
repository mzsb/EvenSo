using BenchmarkDotNet.Running;
using EvenSo.Client.Test;
using EvenSo.Client.Test.TestModel;
using EvenSo.PropertyTrees;

#if RELEASE

BenchmarkRunner.Run<TypeBenchmark>();

#elif DEBUG

var Test = new TestRoot();

var nodes = new PropertyTree3(Test).Nodes.ToArray();

var node = nodes[1];

var i = node.RawValue;

Test.TestList[0].TestBaseListItemId = "3";

var k = node.NewValue;

if (node.IsChanged())
{

    _ = 0;
}

var test = nodes.Where(node => node.IsChanged()).ToArray();

_ = 0;

#endif