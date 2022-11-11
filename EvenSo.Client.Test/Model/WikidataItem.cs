using EvenSo.Logic.Attributes;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenSo.Client.Test.Model
{
    public class WikidataItem : WikidataEntity
    {
        public List<Statement> Statements { get; set; } = new();
    }
}
