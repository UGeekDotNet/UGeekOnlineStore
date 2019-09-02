using Microsoft.EntityFrameworkCore;
using System;
using UGeekStore.Core.Entities;
using UGeekStore.DAL.Entities;
using UGeekStore.DAL.EntityConfigurations;

namespace UGeekStore.DAL
{
    public class StoreContext : DbContext
    {

        public DbSet<Role> Rolies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }



        public StoreContext(DbContextOptions options)
            :base(options)
        {
            Database.EnsureCreated();
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ShipperConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());


            // Tables configurations
            //modelBuilder.ApplyConfiguration(new AccountPermissionConfiguration());
        }
        }
}
