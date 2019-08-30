using Microsoft.EntityFrameworkCore;
using System;
using UGeekStore.DAL.Entities;
using UGeekStore.DAL.EntityConfigurations;

namespace UGeekStore.DAL
{
    public class StoreContext : DbContext
    {
        public DbSet<Shipper> Shippers { get; set; }

        public StoreContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tables configurations
            modelBuilder.ApplyConfiguration(new ShipperConfiguration());
        }
    }
}
