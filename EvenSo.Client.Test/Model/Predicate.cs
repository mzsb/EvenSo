using EvenSo.Logic.Model;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenSo.Client.Test.Model
{
    public class Predicate
    {
        public string Id { get; set; } = "id";

        public List<Label> Labels { get; set; } = new();
    }
}
