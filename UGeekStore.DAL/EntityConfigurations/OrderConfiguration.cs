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

            builder.Property(x => x.OrderDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Address).HasColumnType("NVARCHAR(100)").IsRequired();
            builder.Property(x => x.City).HasColumnType("NVARCHAR(25)").IsRequired();
            builder.Property(x => x.Country).HasColumnType("NVARCHAR(25)").IsRequired();
            builder.Property(x => x.PostalCode).HasColumnType("NVARCHAR(25)").IsRequired();

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.UserID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Shipper)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.ShipperID)
                   .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
