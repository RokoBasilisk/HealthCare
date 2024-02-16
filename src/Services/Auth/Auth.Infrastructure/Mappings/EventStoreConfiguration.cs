using Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Mappings
{
    public class EventStoreConfiguration : IEntityTypeConfiguration<EventStore>
    {
        public void Configure(EntityTypeBuilder<EventStore> builder)
        {
            // Set Id as primary key
            //builder
            //    .HasKey(eventStore => eventStore.Id);

            builder
                .Property(eventStore => eventStore.Id)
                .IsRequired() // Not Null
                .ValueGeneratedNever();

            builder
                .Property(eventStore => eventStore.AggregateId)
                .IsRequired();

            builder
                .Property(eventStore => eventStore.MessageType)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(100);

            builder
                .Property(eventStore => eventStore.Data)
                .IsRequired()
                .IsUnicode(false)
                .HasColumnType("VARCHAR(MAX)")
                .HasComment("JSON serialized event");

            builder
                .Property(eventStore => eventStore.OccurredOn)
                .IsRequired()
                .HasColumnName("CreatedAt");

            builder
                .HasBaseType<EventBase>();
        }
    }
}
