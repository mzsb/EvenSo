using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenSo.Logic.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ListItemAttribute : Attribute
    {
        private readonly string _id;
        public string Id => _id;

        public ListItemAttribute(string id)
        {
            _id = id;
        }
    }
}
