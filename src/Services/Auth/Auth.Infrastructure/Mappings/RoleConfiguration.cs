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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ConfigureBaseEntity();

            builder
                .Property(role => role.RoleName)
                .IsRequired() // Not Null
                .IsUnicode(false) // Varchar
                .HasMaxLength(100);

            builder
                .Property(role => role.RoleDescription)
                .IsRequired() // Not Null
                .IsUnicode(false) // Varchar
                .HasMaxLength(255);
        }
    }
}
