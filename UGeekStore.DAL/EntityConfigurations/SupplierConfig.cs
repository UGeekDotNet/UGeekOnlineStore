using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UGeekStore.DAL.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    public  class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.CompanyName).HasColumnType("nvarchar(100)")
                                                .IsRequired();
            builder.Property(a => a.Address).HasColumnType("nvarchar(50)");
            builder.Property(a => a.City).HasColumnType("nvarchar(25)");
            builder.Property(a => a.Country).HasColumnType("nvarchar(25)");
            builder.Property(a =>a.Status).HasDefaultValue(true);
        }
    }
}
