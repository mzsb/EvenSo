using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenSo.Logic.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ReferenceAttribute : ItemAttribute 
    {
        public ReferenceAttribute(string id, string partitionKey) : base(id, partitionKey) { }
    }
}
