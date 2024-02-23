using Auth.Domain.Entities.EntityAggregate;
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
    public class ClientRoleConfiguration : IEntityTypeConfiguration<ClientRole>
    {
        public void Configure(EntityTypeBuilder<ClientRole> builder)
        {
            builder.HasKey(ur => new { ur.ClientId, ur.RoleId });
        }
    }
}
