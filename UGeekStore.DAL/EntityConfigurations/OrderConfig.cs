using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UGeekStore.DAL.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Date).HasDefaultValueSql("GetDate()");
            builder.Property(a => a.ShipAddress).HasColumnType("nvarchar(100)")
                                                .IsRequired();
            builder.Property(a => a.ShipCity).HasColumnType("nvarchar(25)")
                                             .IsRequired();
            builder.Property(a => a.ShipPostalCode).HasColumnType("nvarchar(10)")
                                                   .IsRequired();
            builder.Property(a => a.ShipCountry).HasColumnType("nvarchar(30)")
                                                .IsRequired();

            builder.HasOne(a => a.User)
                   .WithMany(a => a.Orders)
                   .HasForeignKey(a => a.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Shipper)
                   .WithMany(a => a.Orders)
                   .HasForeignKey(a => a.ShipperId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
