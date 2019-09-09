using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Entities;

namespace UGeekStore.DAL.EntityConfigurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.MessageText).HasColumnType("NVARCHAR(255)").IsRequired();
            builder.Property(x => x.SendTime).HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.Sender)
                   .WithMany(x => x.SendersMessages)
                   .HasForeignKey(x => x.SenderID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Reciver)
                   .WithMany(x => x.ReciversMessages)
                   .HasForeignKey(x => x.ReciverID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
