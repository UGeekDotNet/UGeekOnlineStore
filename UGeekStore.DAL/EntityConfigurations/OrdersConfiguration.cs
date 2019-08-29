using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.DAL.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    public class OrdersConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Users).WithMany(x => x.Orders)
            .HasForeignKey(x => x.UserID).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.OrderDate).HasColumnType("DateTime").HasDefaultValue(DateTime.Now);

            builder.Property(x => x.ShippedDate).HasColumnType("DateTime");

            builder.HasOne(x => x.Shippers).WithMany(x => x.Orders)
            .HasForeignKey(x => x.ShipperID).OnDelete(DeleteBehavior.Restrict); 

            builder.Property(x => x.ShipAddress).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.ShipCity).HasColumnType("nvarchar(25)").IsRequired();
            builder.Property(x => x.ShipCountry).HasColumnType("nvarchar(30)").IsRequired();
            builder.Property(x => x.ShipPostalCode).HasColumnType("nvarchar(15)").IsRequired();




        }
    }
}
