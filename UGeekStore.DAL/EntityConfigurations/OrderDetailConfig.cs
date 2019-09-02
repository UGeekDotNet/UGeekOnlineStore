using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UGeekStore.DAL.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Property(a => a.UnitPrice).HasDefaultValue(0m);
            builder.Property(a => a.Quantity).HasDefaultValue(1);
            builder.Property(a => a.Discount).HasDefaultValue(0);

            builder.HasKey(a => new { a.OrderId, a.ProductId });

            builder.HasOne(a => a.Order)
                   .WithMany(a => a.OrderDetails)
                   .HasForeignKey(a => a.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Product)
                   .WithMany(a => a.OrderDetails)
                   .HasForeignKey(a => a.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
