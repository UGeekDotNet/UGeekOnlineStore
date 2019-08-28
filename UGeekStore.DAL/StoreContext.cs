using Microsoft.EntityFrameworkCore;
using System;

namespace UGeekStore.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options)
            :base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tables configurations
            //modelBuilder.ApplyConfiguration(new AccountPermissionConfiguration());
        }
        }
}
