using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UGeekStore.DAL.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    public class MessageConfig : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Body).HasColumnType("nvarchar(225)")                         .IsRequired();
            builder.Property(a => a.SendTime).HasDefaultValueSql("GetDate()");
           

            builder.HasOne(a => a.Sender)
                   .WithMany(a => a.Messages)
                   .HasForeignKey(a => a.SenderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Reciver)
                   .WithMany(a => a.MessagesReciver)
                   .HasForeignKey(a => a.ReciverId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
