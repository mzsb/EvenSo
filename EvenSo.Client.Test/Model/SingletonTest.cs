using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EvenSo.Client.Test.Model
{
    public class SingletonClass1
    {
        public static readonly SingletonClass1 Instance = new();
        static SingletonClass1() { }
        private SingletonClass1() { }

        public string Test { get; set; } = "Test";
    }

    public abstract class Singleton<T>
    {
        private readonly static T _instance = 
            (T) typeof(T).GetConstructor(
                BindingFlags.Instance | 
                BindingFlags.NonPublic |
                BindingFlags.Public, Array.Empty<Type>())!.Invoke(null);

        public static T Instance => _instance;
    }

    public class SingletonClass2 : Singleton<SingletonClass2>
    {
        private SingletonClass2() { }

        public string Test { get; set; } = "Test";
    }
}
