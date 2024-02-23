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
    public class ClientPasswordConfiguration : IEntityTypeConfiguration<ClientPassword>
    {
        public void Configure(EntityTypeBuilder<ClientPassword> builder)
        {
            builder.ConfigureBaseEntity();

            builder.Property(clientPass => clientPass.Password)
                .IsRequired();

            builder.Property(clientPass => clientPass.PasswordSalt)
                .HasColumnType("bytea")
                .IsRequired();

            builder
                .HasOne(clientPass => clientPass.Client)
                .WithOne(clientPass => clientPass.ClientPassword)
                .HasForeignKey<ClientId>(client => client.ClientPasswordId)
                .IsRequired();
        }
    }
}
