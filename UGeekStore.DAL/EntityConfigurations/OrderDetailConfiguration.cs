using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => new { x.OrderID, x.ProductID });

            builder.HasOne(x => x.Product)
                   .WithMany(x => x.OrderDetails)
                   .HasForeignKey(x => x.ProductID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Order)
                   .WithMany(x => x.OrderDetails)
                   .HasForeignKey(x => x.OrderID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.UnitPrice).HasDefaultValue(0m).IsRequired();
            builder.Property(x => x.Quantity).HasDefaultValue(1).IsRequired();
            builder.Property(x => x.Discount).HasDefaultValue(0).IsRequired();
        }
    }
}
