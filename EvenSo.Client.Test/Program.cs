using BenchmarkDotNet.Running;
using EvenSo;
using EvenSo.Caches;
using EvenSo.Client.Test;
using EvenSo.Client.Test.TestModel;
using EvenSo.Logic.Structures.PropertyTree;
using EvenSo.PropertyTrees;
using EvenSo.Trackers;
using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

#if RELEASE

BenchmarkRunner.Run<TypeBenchmark>();

#elif DEBUG

var test = new TestRoot();

var tracker = new ItemTracker();

tracker.AddOrUpdate(test);

//test.TestDictionary.Add(1,"1");

//test.Key = "TestItemId2";

//test.Type = "TestItemPK2";

//test.TestNull = new object();

//test.TestString = "Test";

//test.TestInt = 1;

//test.TestBool = true;

//test.TestGuid = Guid.NewGuid();

//test.TestDateTime = DateTime.Now;

//test.TestDecimal = 0.2m;

//test.TestArray = new[] { false };

//test.TestPrimitiveList[1] = 1;

test.TestList.RemoveAt(0);

//test.TestChild = new();

//test.TestReferenceChild = new();

tracker.Check(test);


_ = 0;

#endif





