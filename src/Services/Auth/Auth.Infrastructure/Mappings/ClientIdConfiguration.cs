using Auth.Domain.Entities.ClientAggregate;
using Auth.Domain.Entities.RoleAggregate;
using Auth.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Mappings
{
    public class ClientIdConfiguration : IEntityTypeConfiguration<ClientId>
    {
        public void Configure(EntityTypeBuilder<ClientId> builder)
        {
            builder.ConfigureBaseEntity();

            builder.OwnsOne(client => client.Email, ownedNav =>
            {
                ownedNav
                    .Property(email => email.Address)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(256)
                    .HasColumnName(nameof(ClientId.Email));

                // Unique Index
                ownedNav
                    .HasIndex(email => email.Address)
                    .IsUnique();
            });

            builder
                .HasOne(client => client.ClientInformation)
                .WithOne(client => client.Client)
                .HasForeignKey<ClientInformation>(client => client.ClientId)
                .IsRequired();

            builder
                .HasOne(client => client.ClientPassword)
                .WithOne(client => client.Client)
                .HasForeignKey<ClientPassword>(client => client.ClientId)
                .IsRequired();
        }
    }
}
