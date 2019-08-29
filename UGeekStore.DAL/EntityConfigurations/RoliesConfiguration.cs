using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.DAL.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    public class RoliesConfiguration : IEntityTypeConfiguration<Rolies>
    {
        public void Configure(EntityTypeBuilder<Rolies> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.RoleName).HasColumnType("nvarchar(50)");
            builder.Property(x => x.IsDefault).HasColumnType("bit").HasDefaultValue(false);

        }
    }
}
