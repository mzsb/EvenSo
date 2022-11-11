using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenSo.Logic.Extensions
{
    public static class Object
    {
        public static T As<T>(this object obj) => (T) obj;
    }
}
