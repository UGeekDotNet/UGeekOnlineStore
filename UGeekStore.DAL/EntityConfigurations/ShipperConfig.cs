using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UGeekStore.DAL.EntityConfigurations
{
    public class ShipperConfig : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.FirstName).HasColumnType("nvarchar(25)")
                                              .IsRequired();
            builder.Property(a => a.LastName).HasColumnType("nvarchar(50)")
                                             .IsRequired();
            builder.Property(a => a.Address).HasColumnType("nvarchar(100)");
            builder.Property(a => a.City).HasColumnType("nvarchar(25)");
            builder.Property(a => a.Country).HasColumnType("nvarchar(25)");                 
            builder.Property(a => a.Phone).HasColumnType("nvarchar(24)");
            builder.Property(a => a.Email).HasColumnType("nvarchar(25)")
                                          .IsRequired();
            builder.Property(a => a.Salary).HasDefaultValue(80000m);
        }
    }
}
