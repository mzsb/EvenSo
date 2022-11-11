using EvenSo.Logic.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenSo.Client.Test.Model
{

    [ListItem("Id")]
    public abstract class Subject
    {
        public string Id { get; set; } = "id";

        public string Value { get; set; } = "ok";
    }
}
