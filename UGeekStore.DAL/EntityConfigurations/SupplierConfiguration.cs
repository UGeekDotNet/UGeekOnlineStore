using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(X => X.CompanyName).HasColumnType("NVARCHAR(100)").IsRequired();
            builder.Property(x => x.Address).HasColumnType("NVARCHAR(100)");
            builder.Property(x => x.City).HasColumnType("NVARCHAR(25)");
            builder.Property(x => x.Country).HasColumnType("NVARCHAR(30)");
            builder.Property(x => x.Status).HasDefaultValue(true);
            builder.HasIndex(x => x.CompanyName);
        }
    }
}
