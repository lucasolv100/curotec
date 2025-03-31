using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuroTec.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CuroTec.Infrastructure
{
    public class CuroTecContext : DbContext
    {
        public CuroTecContext(DbContextOptions<CuroTecContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vehicle>().ToTable("Vehicles");
        }
    }
}