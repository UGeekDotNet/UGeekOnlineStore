using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.DAL.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    class MessagesConfiguration : IEntityTypeConfiguration<Messages>
    {
        public void Configure(EntityTypeBuilder<Messages> builder)
        {
            builder.HasKey(x => x.Id); // 
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Users).WithMany(x => x.Messages)
            .HasForeignKey(x => x.SenderID).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Users).WithMany(x => x.Messages)
            .HasForeignKey(x => x.ReciverID).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Message).HasColumnType("nvarchar(255)").IsRequired();

            builder.Property(x => x.SendTime).HasColumnType("DateTime").HasDefaultValue(DateTime.Now);

            builder.Property(x => x.ReadDate).HasColumnType(DateTime.Now);

        }
    }
}
