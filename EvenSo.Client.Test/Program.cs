
using EvenSo.Client.Test.TestModel;
using EvenSo.Logic;

var t = new UpdateTracker();

var item = new TestRoot();
//var item = new WikidataItem();

//item.Labels.Add(new Label { Language = "en", Value = "Adams" });
//item.Statements.Add(new Statement
//{
//    Predicate = new Predicate(),
//    Subjects = new() 
//    {
//        new Item
//        {
//          Id = "test id",
//          Value = "test PK",
//          Labels = new () { new Label { Language = "en", Value = "Adams" } }
//        }
//    }
//});

t.Travel2(item);

//item.List.Add(new ListItem { ListItemId = "10", Ref = true });
//t.Track(item);

//t.BeforUpdate(item);

//item.List.Add(new ListItem { ListItemId = "20", Ref = true });
//var p = item.List.First();
//p.Ref = false;

////item.TestProperty = DateTime.Now;
////item.List.First().ListItemId = null;
////item.referencedItem.ReferencedProperty = 10;

//t.DetectChanges(item);

Console.WriteLine("kész");

//test.Start();

//Console.WriteLine("majom");

//test.Wait();

//Console.WriteLine("ok");

//BenchmarkRunner.Run<ReflectionBenchmark>();

//WikidataEntity i = new WikidataItem();

//var type = i.IsIdentifiable();

//var id = i.GetId();
//var partitionKey = i.GetPartitionKey();

//var p = i.GetProperties()[0].GetValue(i);

//_ = 0;


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
