using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UGeekStore.DAL.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).HasColumnType("nvarchar(40)")
                                         .IsRequired();
            builder.HasIndex(a => a.Name);
            builder.Property(a => a.Description).HasColumnType("nvarchar(225)");                               
            builder.Property(a => a.UnitPrice).HasDefaultValue(0m);
            builder.Property(a => a.Weight).HasDefaultValue(0);
            builder.Property(a => a.AddDate).HasDefaultValueSql("GetDate()");
            builder.Property(a => a.Count).HasDefaultValue(0);

            builder.HasOne(a => a.Supplier)
                   .WithMany(a => a.Products)
                   .HasForeignKey(a=>a.SupplierId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Category)
                   .WithMany(a => a.Products)
                   .HasForeignKey(a => a.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);  
        }
    }
}
