using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
   public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.User)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.UserID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.OrderDate).HasColumnType("DateTime").HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ShippedDate).HasColumnType("DateTime");
            builder.HasOne(x => x.Shipper)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.ShipperID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Address).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.City).HasColumnType("nvarchar(25)").IsRequired();
            builder.Property(x => x.Country).HasColumnType("nvarchar(30)").IsRequired();
            builder.Property(x => x.PostalCode).HasColumnType("nvarchar(15)").IsRequired();

        }
    }
}
