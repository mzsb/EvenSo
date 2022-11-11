using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenSo.Logic.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ItemAttribute : Attribute
    {
        private readonly string _id;

        private readonly string _partitonKey;
        public string Id => _id;
        public string PartitonKey => _partitonKey;

        public ItemAttribute(string id, string partitionKey)
        {
            _id = id;
            _partitonKey = partitionKey;
        }
    }
}
