using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.DAL.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    class ShippersConfiguration : IEntityTypeConfiguration<Shippers>
    {
        public void Configure(EntityTypeBuilder<Shippers> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName).HasColumnType("nvarchar(15)").IsRequired();
            builder.Property(x => x.LastName).HasColumnType("nvarchar(30)").IsRequired();
            builder.Property(x => x.BirthDate).HasColumnType("DateTime");
            builder.Property(x => x.Address).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.City).HasColumnType("nvarchar(25)").IsRequired();
            builder.Property(x => x.Country).HasColumnType("nvarchar(25)").IsRequired();
            builder.Property(x => x.Phone).HasColumnType("varchar(12)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.Salary).HasDefaultValue(80000m);


            builder.HasAlternateKey(x => new { x.Phone, x.Email });
        }
    }
}
