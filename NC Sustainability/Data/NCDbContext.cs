using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NCSustainability.Models;
using NCSustainability.ViewModels;

namespace NCSustainability.Data
{
    public class NCDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string UserName
        {
            get; private set;
        }
        public NCDbContext (DbContextOptions<NCDbContext> options)
            : base(options)
        {
            UserName = "SeedData";
        }


        public NCDbContext(DbContextOptions<NCDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            UserName = _httpContextAccessor.HttpContext?.User.Identity.Name;
            //UserName = (UserName == null) ? "Unknown" : UserName;
            UserName = UserName ?? "Unknown";
        }
        public DbSet<Event> Events { get; set; }

        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<Subscriber> subscribers { get; set; }

        public DbSet<AssignedOptionVM> AssignedOptionVM { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            

        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

    }
}
