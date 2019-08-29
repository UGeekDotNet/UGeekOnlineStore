using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.DAL.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    class OrderDetalisConfiguration : IEntityTypeConfiguration<OrderDetalis>
    {
        public void Configure(EntityTypeBuilder<OrderDetalis> builder)
        {
            builder.HasOne(x => x.Products).WithMany(x => x.OrderDetalis)
            .HasForeignKey(x => x.ProductID).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Orders).WithMany(x => x.OrderDetalis)
            .HasForeignKey(x => x.OrderID).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.UnitPrice).HasDefaultValue(0m).IsRequired();
            builder.Property(x => x.Quantity).HasDefaultValue(1).IsRequired();
            builder.Property(x => x.Discount).HasDefaultValue(0).IsRequired();
        }
    }
}
