using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.UserName).HasColumnType("NVARCHAR(50)").IsRequired();
            builder.Property(x => x.Password).HasColumnType("NVARCHAR(25)").IsRequired();
            builder.Property(x => x.FirstName).HasColumnType("NVARCHAR(30)").IsRequired();
            builder.Property(x => x.LastName).HasColumnType("NVARCHAR(40)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("NVARCHAR(50)").IsRequired();
            builder.Property(x => x.RegisterDate).HasColumnType("DATE").HasDefaultValue(DateTime.Now.Date);
            builder.Property(x => x.Address).HasColumnType("NVARCHAR(100)");
            builder.Property(x => x.City).HasColumnType("NVARCHAR(30)");
            builder.Property(x => x.Country).HasColumnType("NVARCHAR(30)");
            builder.Property(x => x.PostalCode).HasColumnType("NVARCHAR(10)");

            builder.HasAlternateKey(x => x.UserName);
            builder.HasAlternateKey(x => x.Email);

            builder.HasIndex(x => x.FirstName);

            builder.HasOne(x => x.Role)
                   .WithMany(x => x.Users)
                   .HasForeignKey(x => x.AccessID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
