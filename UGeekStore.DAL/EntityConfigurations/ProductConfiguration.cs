using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.CategoryID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Supplier)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.SupplierID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Name).HasColumnType("nvarchar(40)").IsRequired();
            builder.HasIndex(x => x.Name);
            builder.Property(x => x.UnitPrice).HasDefaultValue(0m);
            builder.Property(x => x.Weight).HasDefaultValue(0f);
            builder.Property(x => x.Description).HasColumnType("nvarchar(255)");
            builder.Property(x => x.AddedDate).HasColumnType("Date").HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Count).HasDefaultValue(0);

        }
    }
}
