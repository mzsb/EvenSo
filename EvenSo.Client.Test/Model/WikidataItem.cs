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
        public string? Test { get; set; } = null;
        public List<Statement> Statements { get; set; } = new();
    }
}
