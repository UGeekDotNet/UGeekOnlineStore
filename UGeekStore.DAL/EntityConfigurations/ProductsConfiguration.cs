using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.DAL.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Categories).WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryID).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Suppliers).WithMany(x => x.Products)
            .HasForeignKey(x => x.SupplierID).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.ProductName).HasColumnType("nvarchar(40)").IsRequired();
            builder.HasIndex(x => x.ProductName);
            builder.Property(x => x.UnitPrice).HasDefaultValue(0m);
            builder.Property(x => x.Weight).HasDefaultValue(0f);
            builder.Property(x => x.Description).HasColumnType("nvarchar(255)");
            builder.Property(x => x.AddedDate).HasColumnType("Date").HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Count).HasDefaultValue(0);


        }
    }
}
