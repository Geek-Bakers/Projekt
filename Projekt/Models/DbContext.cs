using Microsoft.EntityFrameworkCore;
using Projekt.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class ProjektDBContext : DbContext
    {
        public ProjektDBContext(DbContextOptions<ProjektDBContext> options)
          : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Resource> Resources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ResourceConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
