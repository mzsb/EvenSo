
using BenchmarkDotNet.Running;
using EvenSo.Client.Test;
using EvenSo.Client.Test.Model;
using EvenSo.Client.Test.TestModel;
using EvenSo.Keys;
using EvenSo.Logic;
using EvenSo.Logic.Extensions;
using EvenSo.Nodes;
using Microsoft.CodeAnalysis.Text;
using System.Diagnostics;
using System.Net;


//var item = new TestRoot();

//var n = item.GetNodess().ToArray();

//var s = new TestRoot();

//var g = s.GetNodess().ToArray();
//var n = s.GetNodess().ToArray();

//_ = 0;
//var itemChange = item.Track();

BenchmarkRunner.Run<ReflectionBenchmark>();

//item.TestNull = new();
//item.TestInt = 5;
//item.TestDateTime = DateTime.Now;
//item.TestString = "okk";
//item.TestDecimal = 5.6m;
//item.TestGuid = Guid.NewGuid();

//if(itemChange.GetChanges(out var changes))
//{
//    _ = changes;
//}

//var cosmosClient = new CosmosClientBuilder("AccountEndpoint=https://wikidatacosmosdb.documents.azure.com:443/;AccountKey=BtXWfCZaJdvk38LqwMT1HpV4GYuAL52QwChnhdOOuD25S4dlyyRNlxaynWbJhgOMtZmopn7OdNAxu5GlN4qlqQ==;")
//    .WithSerializerOptions(
//        new CosmosSerializationOptions
//        {
//            PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
//        })
//    .WithBulkExecution(false)
//    .Build();

//var container = cosmosClient.GetEventContainer("test-database", "test-container");

//WikidataItem wikidataItem = new WikidataItem
//{
//    Id = "Q42",
//    Predicate = new() { Id = "Ok" },
//    Statements = new ()
//    {
//        new ()
//        {
//            Predicate = new ()
//            {
//                Id = "P31",
//                Labels = new ()
//                {
//                    new ()
//                    {
//                        Language = "en", 
//                        Value = "instace of"
//                    }
//                }
//            },
//            Subjects = new ()
//            {
//                new Item
//                {
//                    Id = "Q21",
//                    Labels = new ()
//                    {
//                        new ()
//                        {
//                            Language = "en",
//                            Value = "human"
//                        }
//                    }
//                }
//            }
//        }
//    }
//};

//foreach (var property in wikidataItem.GetType().GetProperties())
//{
//    var value = property.GetValue(wikidataItem);
//    Console.WriteLine(value);
//}

//Console.WriteLine();


//foreach (var property in Visitor<WikidataItem>.ChachedProperties)
//{
//    var value = property(wikidataItem);
//    Console.WriteLine(value);
//}

//_ = 0;
