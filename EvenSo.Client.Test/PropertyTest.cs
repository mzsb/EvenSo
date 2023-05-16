using EvenSo.Caches;
using EvenSo.Client.Test.TestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenSo.Client.Test
{
    //public class PropertyTest1
    //{

    //    public Guid Property1 { get; set; } = Guid.NewGuid();


    //    public Guid Property2 { get; set; } = Guid.NewGuid();


    //    public Guid Property3 { get; set; } = Guid.NewGuid();


    //    public Guid Property4 { get; set; } = Guid.NewGuid();


    //    public Guid Property5 { get; set; } = Guid.NewGuid();


    //    public Guid Property6 { get; set; } = Guid.NewGuid();


    //    public Guid Property7 { get; set; } = Guid.NewGuid();


    //    public DateTime Property8 { get; set; } = DateTime.Now;


    //    public DateTime Property9 { get; set; } = DateTime.Now;


    //    public DateTime Property10 { get; set; } = DateTime.Now;

    //    public DateTime Property11 { get; set; } = DateTime.Now;


    //    public DateTime Property12 { get; set; } = DateTime.Now;


    //    public DateTime Property13 { get; set; } = DateTime.Now;


    //    public DateTime Property14 { get; set; } = DateTime.Now;


    //    public string Property15 { get; set; } = "majom";


    //    public string Property16 { get; set; } = "majom";


    //    public string Property17 { get; set; } = "majom";


    //    public string Property18 { get; set; } = "majom";


    //    public string Property19 { get; set; } = "majom";


    //    public string Property20 { get; set; } = "majom";

    //    public string Property21 { get; set; } = "majom";


    //    public string Property22 { get; set; } = "majom";


    //    public string Property23 { get; set; } = "majom";


    //    public string Property24 { get; set; } = "majom";


    //    public string Property25 { get; set; } = "majom";


    //    public string Property26 { get; set; } = "majom";


    //    public string Property27 { get; set; } = "majom";


    //    public string Property28 { get; set; } = "majom";


    //    public string Property29 { get; set; } = "majom";


    //    public string Property30 { get; set; } = "majom";

    //    public string Property31 { get; set; } = "majom";


    //    public string Property32 { get; set; } = "majom";


    //    public string Property33 { get; set; } = "majom";


    //    public string Property34 { get; set; } = "majom";


    //    public string Property35 { get; set; } = "majom";


    //    public string Property36 { get; set; } = "majom";


    //    public string Property37 { get; set; } = "majom";


    //    public string Property38 { get; set; } = "majom";


    //    public string Property39 { get; set; } = "majom";


    //    public string Property40 { get; set; } = "majom";

    //    public string Property41 { get; set; } = "majom";


    //    public string Property42 { get; set; } = "majom";


    //    public string Property43 { get; set; } = "majom";


    //    public string Property44 { get; set; } = "majom";


    //    public string Property45 { get; set; } = "majom";


    //    public string Property46 { get; set; } = "majom";


    //    public string Property47 { get; set; } = "majom";


    //    public string Property48 { get; set; } = "majom";


    //    public string Property49 { get; set; } = "majom";


    //    public string Property50 { get; set; } = "majom";
    //}

    //public class PropertyTest2
    //{
    //    public PropertyTest1[] List6 { get; set; } =
    //        Enumerable.Range(0, 10).Select(_ => new PropertyTest1()).ToArray();

    //    public List<PropertyTest1> List7 { get; set; } =
    //        Enumerable.Range(0, 10).Select(_ => new PropertyTest1()).ToList();

    //    public PropertyTest1[] List8 { get; set; } =
    //        Enumerable.Range(0, 10).Select(_ => new PropertyTest1()).ToArray();

    //    public List<PropertyTest1> List9 { get; set; } =
    //        Enumerable.Range(0, 10).Select(_ => new PropertyTest1()).ToList();

    //    public PropertyTest1[] List10 { get; set; } =
    //        Enumerable.Range(0, 10).Select(_ => new PropertyTest1()).ToArray();
    //}

    //public class PropertyTest3
    //{
    //    public BasePropertyTest4[] List1 { get; set; } =
    //        Enumerable.Range(0, 10).Select(i => i % 2 == 0 ? new BasePropertyTest4() : new PropertyTest4()).ToArray();

    //    public List<BasePropertyTest4> List2 { get; set; } =
    //        Enumerable.Range(0, 10).Select(i => i % 2 == 0 ? new BasePropertyTest4() : new PropertyTest4()).ToList();

    //    public BasePropertyTest4[] List3 { get; set; } =
    //        Enumerable.Range(0, 10).Select(i => i % 2 == 0 ? new BasePropertyTest4() : new PropertyTest4()).ToArray();

    //    public List<BasePropertyTest4> List4 { get; set; } =
    //        Enumerable.Range(0, 10).Select(i => i % 2 == 0 ? new BasePropertyTest4() : new PropertyTest4()).ToList();

    //    public BasePropertyTest4[] List5 { get; set; } =
    //        Enumerable.Range(0, 10).Select(i => i % 2 == 0 ? new BasePropertyTest4() : new PropertyTest4()).ToArray();
    //}

    //public class BasePropertyTest4
    //{
    //    public Guid Property1 { get; set; } = Guid.NewGuid();


    //    public Guid Property2 { get; set; } = Guid.NewGuid();


    //    public Guid Property3 { get; set; } = Guid.NewGuid();


    //    public Guid Property4 { get; set; } = Guid.NewGuid();


    //    public Guid Property5 { get; set; } = Guid.NewGuid();


    //    public Guid Property6 { get; set; } = Guid.NewGuid();


    //    public Guid Property7 { get; set; } = Guid.NewGuid();


    //    public DateTime Property8 { get; set; } = DateTime.Now;


    //    public DateTime Property9 { get; set; } = DateTime.Now;


    //    public DateTime Property10 { get; set; } = DateTime.Now;

    //    public DateTime Property11 { get; set; } = DateTime.Now;


    //    public DateTime Property12 { get; set; } = DateTime.Now;


    //    public DateTime Property13 { get; set; } = DateTime.Now;


    //    public DateTime Property14 { get; set; } = DateTime.Now;


    //    public string Property15 { get; set; } = "majom";


    //    public string Property16 { get; set; } = "majom";


    //    public string Property17 { get; set; } = "majom";


    //    public string Property18 { get; set; } = "majom";


    //    public string Property19 { get; set; } = "majom";


    //    public string Property20 { get; set; } = "majom";

    //    public string Property21 { get; set; } = "majom";


    //    public string Property22 { get; set; } = "majom";


    //    public string Property23 { get; set; } = "majom";


    //    public string Property24 { get; set; } = "majom";


    //    public string Property25 { get; set; } = "majom";


    //    public string Property26 { get; set; } = "majom";


    //    public string Property27 { get; set; } = "majom";


    //    public string Property28 { get; set; } = "majom";


    //    public string Property29 { get; set; } = "majom";


    //    public string Property30 { get; set; } = "majom";

    //    public string Property31 { get; set; } = "majom";


    //    public string Property32 { get; set; } = "majom";


    //    public string Property33 { get; set; } = "majom";


    //    public string Property34 { get; set; } = "majom";


    //    public string Property35 { get; set; } = "majom";


    //    public string Property36 { get; set; } = "majom";


    //    public string Property37 { get; set; } = "majom";


    //    public string Property38 { get; set; } = "majom";


    //    public string Property39 { get; set; } = "majom";


    //    public string Property40 { get; set; } = "majom";

    //    public string Property41 { get; set; } = "majom";


    //    public string Property42 { get; set; } = "majom";


    //    public string Property43 { get; set; } = "majom";


    //    public string Property44 { get; set; } = "majom";


    //    public string Property45 { get; set; } = "majom";


    //    public string Property46 { get; set; } = "majom";


    //    public string Property47 { get; set; } = "majom";


    //    public string Property48 { get; set; } = "majom";


    //    public string Property49 { get; set; } = "majom";


    //    public string Property50 { get; set; } = "majom";
    //}

    //public class PropertyTest4 : BasePropertyTest4
    //{
    //    public PropertyTest2 Proper1ty11 { get; set; } = new();


    //    public PropertyTest2 Prope1rty21 { get; set; } = new();


    //    public PropertyTest2 Propert1y31 { get; set; } = new();


    //    public PropertyTest2 Propert1y41 { get; set; } = new();


    //    public PropertyTest1 Property51 { get; set; } = new();


    //    public PropertyTest1 Property61 { get; set; } = new();


    //    public string Property71 { get; set; } = "majom";


    //    public int Property81 { get; set; } = 10;


    //    public bool Property91 { get; set; } = true;


    //    public DateTime Property101 { get; set; } = DateTime.Now;

    //    public string Property111 { get; set; } = "majom";


    //    public string Property121 { get; set; } = "majom";


    //    public string Property131 { get; set; } = "majom";


    //    public string Property141 { get; set; } = "majom";


    //    public string Property151 { get; set; } = "majom";


    //    public string Property161 { get; set; } = "majom";


    //    public string Property171 { get; set; } = "majom";


    //    public string Property181 { get; set; } = "majom";


    //    public string Property191 { get; set; } = "majom";


    //    public string Property201 { get; set; } = "majom";

    //    public string Property211 { get; set; } = "majom";


    //    public string Property221 { get; set; } = "majom";


    //    public string Property231 { get; set; } = "majom";


    //    public string Property241 { get; set; } = "majom";


    //    public string Property251 { get; set; } = "majom";


    //    public string Property216 { get; set; } = "majom";


    //    public string Property127 { get; set; } = "majom";


    //    public string Propert1y28 { get; set; } = "majom";


    //    public string Property129 { get; set; } = "majom";


    //    public string Propert1y30 { get; set; } = "majom";

    //    public string Propert1y131 { get; set; } = "majom";


    //    public string Propert1y32 { get; set; } = "majom";


    //    public string Proper1ty33 { get; set; } = "majom";


    //    public string Proper1ty34 { get; set; } = "majom";


    //    public string Proper1ty35 { get; set; } = "majom";


    //    public string Proper1ty36 { get; set; } = "majom";


    //    public string Proper1ty37 { get; set; } = "majom";


    //    public string Propert1y38 { get; set; } = "majom";


    //    public string Propert1y39 { get; set; } = "majom";


    //    public string Propert1y40 { get; set; } = "majom";

    //    public string Propert11y41 { get; set; } = "majom";


    //    public string Propert1y42 { get; set; } = "majom";


    //    public string Propert1y43 { get; set; } = "majom";


    //    public string Propert1y44 { get; set; } = "majom";


    //    public string Propert1y45 { get; set; } = "majom";


    //    public string Property146 { get; set; } = "majom";


    //    public string Propert1y47 { get; set; } = "majom";


    //    public string Property148 { get; set; } = "majom";


    //    public string Property419 { get; set; } = "majom";


    //    public string Property510 { get; set; } = "majom";
    //}

    public class PropertyTest6
    {
        public List<PropertyTestt0> MyProperty0 { get; set; } =
             Enumerable.Range(0, 10).Select(_ => new PropertyTestt0()).ToList();

        public List<PropertyTestt16> MyProperty16 { get; set; } = 
            Enumerable.Range(0, 10).Select(_ => new PropertyTestt16()).ToList();

        public List<PropertyTestt17> MyProperty17 { get; set; } =
    Enumerable.Range(0, 10).Select(_ => new PropertyTestt17()).ToList();

        public List<PropertyTestt18> MyProperty18 { get; set; } =
    Enumerable.Range(0, 10).Select(_ => new PropertyTestt18()).ToList();

        public List<PropertyTestt19> MyProperty19 { get; set; } =
    Enumerable.Range(0, 10).Select(_ => new PropertyTestt19()).ToList();

        public List<PropertyTestt20> MyProperty20 { get; set; } =
    Enumerable.Range(0, 10).Select(_ => new PropertyTestt20()).ToList();

        public List<PropertyTestt21> MyProperty21 { get; set; } =
    Enumerable.Range(0, 10).Select(_ => new PropertyTestt21()).ToList();

        public List<PropertyTestt22> MyProperty22 { get; set; } =
    Enumerable.Range(0, 10).Select(_ => new PropertyTestt22()).ToList();

        public List<PropertyTestt23> MyProperty23 { get; set; } =
    Enumerable.Range(0, 10).Select(_ => new PropertyTestt23()).ToList();

        public List<PropertyTestt24> MyProperty24 { get; set; } =
    Enumerable.Range(0, 10).Select(_ => new PropertyTestt24()).ToList();

        public List<PropertyTestt25> MyProperty25 { get; set; } =
    Enumerable.Range(0, 10).Select(_ => new PropertyTestt25()).ToList();

        public List<PropertyTestt26> MyProperty26 { get; set; } =
    Enumerable.Range(0, 10).Select(_ => new PropertyTestt26()).ToList();

        public List<PropertyTestt27> MyProperty27 { get; set; } =
    Enumerable.Range(0, 10).Select(_ => new PropertyTestt27()).ToList();

        public List<PropertyTestt28> MyProperty28 { get; set; } =
    Enumerable.Range(0, 10).Select(_ => new PropertyTestt28()).ToList();

        public List<PropertyTestt29> MyProperty29 { get; set; } =
    Enumerable.Range(0, 10).Select(_ => new PropertyTestt29()).ToList();

        public List<PropertyTestt30> MyProperty30 { get; set; } =
    Enumerable.Range(0, 10).Select(_ => new PropertyTestt30()).ToList();
    }

    public class PropertyTestt0
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";

        public PropertyTestt1 PropertyTest1 { get; set; } = new();
    }

    public class PropertyTestt1
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";

        public PropertyTestt2 PropertyTest2 { get; set; } = new();
    }


    public class PropertyTestt2
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";

        public PropertyTestt3 PropertyTest3 { get; set; } = new();
    }

    public class PropertyTestt3
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";

        public PropertyTestt4 PropertyTest4 { get; set; } = new();
    }

    public class PropertyTestt4
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";

        public PropertyTestt5 PropertyTest5 { get; set; } = new();
    }

    public class PropertyTestt5
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";

        public PropertyTestt6 PropertyTest6 { get; set; } = new();
    }

    public class PropertyTestt6
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";

        public PropertyTestt7 PropertyTest7 { get; set; } = new();
    }

    public class PropertyTestt7
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";

        public PropertyTestt8 PropertyTest8 { get; set; } = new();
    }

    public class PropertyTestt8
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";

        public PropertyTestt9 PropertyTest9 { get; set; } = new();
    }

    public class PropertyTestt9
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";

        public PropertyTestt10 PropertyTest10 { get; set; } = new();
    }

    public class PropertyTestt10
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";

        public PropertyTestt11 PropertyTest11 { get; set; } = new();
    }

    public class PropertyTestt11
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";
        public PropertyTestt12 PropertyTest12 { get; set; } = new();
    }

    public class PropertyTestt12
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";

        public PropertyTestt13 PropertyTest13 { get; set; } = new();
    }

    public class PropertyTestt13
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";

        public PropertyTestt14 PropertyTest14 { get; set; } = new();
    }

    public class PropertyTestt14
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";

        public PropertyTestt15 PropertyTest15 { get; set; } = new();
    }

    public class PropertyTestt15
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";
    }

    public class PropertyTestt16
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";
    }

    public class PropertyTestt17
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";
    }

    public class PropertyTestt18
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";
    }

    public class PropertyTestt19
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";
    }

    public class PropertyTestt20
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";
    }

    public class PropertyTestt21
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";
    }

    public class PropertyTestt22
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";
    }

    public class PropertyTestt23
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";
    }

    public class PropertyTestt24
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";
    }

    public class PropertyTestt25
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";
    }

    public class PropertyTestt26
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";
    }

    public class PropertyTestt27
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";
    }

    public class PropertyTestt28
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";
    }

    public class PropertyTestt29
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";
    }

    public class PropertyTestt30
    {
        [Key(KeyType.Id)]
        public string Key { get; set; } = "TestItemId";

        [Key(KeyType.PartitionKey)]
        public string Type { get; set; } = "TestItemPK";
    }
}
