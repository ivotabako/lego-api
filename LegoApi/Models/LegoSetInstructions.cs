using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.Models
{
    public class LegoSetInstructionsPage
    {
        public Guid Id { get; set; }

        public int PageNumber { get; set; }

        public Uri Link { get; set; }

        public LegoSet LegoSet { get; set; }
    }
}
