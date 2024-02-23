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
    public class ClientInformationConfiguration : IEntityTypeConfiguration<ClientInformation>
    {
        public void Configure(EntityTypeBuilder<ClientInformation> builder)
        {
            builder.ConfigureBaseEntity();

            builder.Property(clientInfo => clientInfo.Name)
                .IsRequired();

            builder.Property(clientInfo => clientInfo.ExpiredDate)
                .IsRequired();

            builder.Property(clientInfo => clientInfo.IsLocked)
                .IsRequired();

            builder.OwnsOne(clientInfo => clientInfo.Gender, ownedNav =>
            {
                ownedNav
                    .Property(gender => gender.Id)
                    .IsRequired()
                    .HasColumnName(nameof(ClientInformation.Gender));

                ownedNav
                    .Ignore(gender => gender.Value);
            });

            builder
                .HasOne(clientInfo => clientInfo.Client)
                .WithOne(clientInfo => clientInfo.ClientInformation)
                .HasForeignKey<ClientId>(client => client.ClientInformationId)
                .IsRequired();
        }
    }
}
