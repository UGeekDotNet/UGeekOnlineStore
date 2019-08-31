using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    public class OrderDetalisConfiguration : IEntityTypeConfiguration<OrderDetalis>
    {
        public void Configure(EntityTypeBuilder<OrderDetalis> builder)
        {
            builder.HasKey(x => new { x.OrderID, x.ProductID });

            builder.HasOne(x => x.Product)
                   .WithMany(x => x.OrderDetalis)
                   .HasForeignKey(x => x.ProductID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Order)
                   .WithMany(x => x.OrderDetalis)
                   .HasForeignKey(x => x.OrderID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.UnitPrice).HasDefaultValue(0m).IsRequired();
            builder.Property(x => x.Quantity).HasDefaultValue(1).IsRequired();
            builder.Property(x => x.Discount).HasDefaultValue(0).IsRequired();
        }
    }
}
