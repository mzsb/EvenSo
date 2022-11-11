using EvenSo.Logic.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using System.Threading.Tasks;

namespace EvenSo.Client.Test.Model
{

    [Item("Predicate/Id", "Value")]
    public class Statement
    {
        public Predicate Predicate { get; set; } = new();

        public string Value { get; set; } = "value";

        public List<Subject> Subjects { get; set; } = new();
    }
}
