using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LegoApi.Models;

namespace LegoApi.Data
{
    public class LegoApiContext : DbContext
    {
        public LegoApiContext (DbContextOptions<LegoApiContext> options)
            : base(options)
        {
        }

        public DbSet<LegoApi.Models.LegoSet> LegoSet { get; set; }
    }
}
