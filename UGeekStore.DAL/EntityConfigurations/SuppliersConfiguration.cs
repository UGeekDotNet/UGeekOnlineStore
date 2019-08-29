using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.DAL.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    class SuppliersConfiguration : IEntityTypeConfiguration<Suppliers>
    {
        public void Configure(EntityTypeBuilder<Suppliers> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CompanyName).HasColumnType("nvarchar(100)");

            builder.HasAlternateKey(x => x.CompanyName);
            builder.Property(x => x.Adress).HasColumnType("nvarchar(50)");
            builder.Property(x => x.City).HasColumnType("nvarchar(25)");
            builder.Property(x => x.Country).HasColumnType("nvarchar()25");

            builder.Property(x => x.Status).HasColumnType("bit").HasDefaultValue(1);








        }
    }
}


