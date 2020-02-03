using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NC_Sustainability.Models;

namespace NC_Sustainability.Data
{
    public class NCDbContext : DbContext
    {
        public NCDbContext (DbContextOptions<NCDbContext> options)
            : base(options)
        {
        }

        public DbSet<NC_Sustainability.Models.Event> Events { get; set; }

        public DbSet<NC_Sustainability.Models.EventCategory> EventCategories { get; set; }
    }
}
