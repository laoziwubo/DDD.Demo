using System;
using System.Collections.Generic;
using System.Text;
using DDD.Domain.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infrastructure.Data.Mapping
{
    public class StoredEventMap : IEntityTypeConfiguration<StoredEvent>
    {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.Property(c => c.Timestamp)
                .HasColumnName("CreationDate")
                .HasColumnType("datetime");

            builder.Property(c => c.MessageType)
                .HasColumnName("Action")
                .HasColumnType("varchar(100)");
        }
    }
}
