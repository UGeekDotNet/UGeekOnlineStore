using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.DAL.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    class CategoriesConfiguration : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CategoryName).HasColumnType("nvarchar(30)").IsRequired();

            builder.HasAlternateKey(x => x.CategoryName);
        }
    }
}
