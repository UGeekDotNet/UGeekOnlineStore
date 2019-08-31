using Microsoft.EntityFrameworkCore;
using System;
using UGeekStore.DAL.Entities;
using UGeekStore.DAL.EntityConfigurations;

namespace UGeekStore.DAL
{
    public class StoreContext : DbContext
    {

        public DbSet<Rolies> Rolies { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Shippers> Shippers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetalis> OrderDetalis { get; set; }



        public StoreContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoliesConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new MessagesConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new SuppliersConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());
            modelBuilder.ApplyConfiguration(new ShippersConfiguration());
            modelBuilder.ApplyConfiguration(new OrdersConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetalisConfiguration());


            // Tables configurations
            modelBuilder.ApplyConfiguration(new ShipperConfiguration());
        }
    }
}
