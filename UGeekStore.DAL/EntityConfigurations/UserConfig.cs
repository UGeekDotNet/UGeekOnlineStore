using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UGeekStore.DAL.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).HasColumnType("nvarchar(30)")
                                         .IsRequired();
            builder.HasAlternateKey(a => a.Name);
            builder.Property(a => a.Password).HasColumnType("nvarchar(25)")
                                             .IsRequired();
            builder.Property(a => a.FirstName).HasColumnType("nvarchar(30)")
                                              .IsRequired();
            builder.Property(a => a.LastName).HasColumnType("nvarchar(50)")
                                             .IsRequired();
            builder.Property(a => a.Email).HasColumnType("nvarchar(50)");
            builder.HasAlternateKey(a => a.Email);
            builder.Property(a => a.RegisterDate).HasDefaultValueSql("GetDate()");
            builder.Property(a => a.ShipPostalCode).HasColumnType("nvarchar(10)");
            builder.Property(a => a.City).HasColumnType("nvarchar(25)");
            builder.Property(a => a.Country).HasColumnType("nvarchar(30)");
            builder.Property(a => a.ShipAddress).HasColumnType("nvarchar(100)");
            builder.HasIndex(a => a.Name);
            builder.HasIndex(a => a.FirstName);

            builder.HasOne(a => a.Role)
                   .WithMany(a => a.Users)
                   .HasForeignKey(a => a.AccessId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
