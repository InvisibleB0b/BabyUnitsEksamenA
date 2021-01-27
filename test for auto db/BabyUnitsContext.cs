using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyUnitsEksamenA;
using Microsoft.EntityFrameworkCore;

namespace test_for_auto_db
{
    public class BabyUnitsContext : DbContext
    {
        public BabyUnitsContext(DbContextOptions<BabyUnitsContext> options) : base(options)
        {

        }

        public DbSet<BabyUnit> babyUnits { get; set; }
    }
}
