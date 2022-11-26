﻿using EvenSo.Logic.Model;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenSo.Client.Test.Model
{
    public class Item : Subject
    {
        public string PK { get; set; } = "PK";
        public List<Label> Labels { get; set; } = new();
    }
}
