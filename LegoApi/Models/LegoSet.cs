﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.Models
{
    public class LegoSet
    {
        public Guid Id { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public Uri Link { get; set; }

        public int IdNumber { get; set; }

        public List<LegoSetInstructionsPage> Instructions { get; set; }
    }
}
