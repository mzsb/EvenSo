using EvenSo.Logic.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenSo.Client.Test.Model
{
    [ListItem("Language")]
    public class Label
    {
        [Referenced]
        public string Language { get; set; } = "language";
        public string Value { get; set; } = "value";
    }
}
