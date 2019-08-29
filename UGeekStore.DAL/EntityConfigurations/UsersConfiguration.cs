using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.DAL.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Rolies).WithMany(x => x.Users)
            .HasForeignKey(x => x.AccessID).OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.UserName).HasColumnType("nvarchar(30)").IsRequired();

            builder.Property(x => x.Password).HasColumnType("nvarchar(25)").IsRequired();
            builder.Property(x => x.FirstName).HasColumnType("nvarchar(20)").IsRequired(); 
            builder.Property(x => x.LastName).HasColumnType("nvarchar(30)").IsRequired(); 
            builder.Property(x => x.Email).HasColumnType("nvarchar(50)").IsRequired(); 
            builder.Property(x => x.RegistrDate).HasColumnType("Date").HasDefaultValue("GetDate()");
            builder.Property(x => x.ShipAddress).HasColumnType("nvarchar(50)");
            builder.Property(x => x.City).HasColumnType("nvarchar(25)");
            builder.Property(x => x.Country).HasColumnType("nvarchar(30)");
            builder.Property(x => x.ShipPostalCode).HasColumnType("nvarchar(10)");


            builder.HasAlternateKey(x => new { x.UserName, x.Email });
            builder.HasIndex(x => new { x.UserName, x.FirstName, x.LastName });







        }
    }
}
