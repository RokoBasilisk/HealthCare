using Auth.Domain.Entities.ClientAggregate;
using Auth.Domain.Entities.EntityAggregate;
using Auth.Domain.Entities.RoleAggregate;
using Auth.Infrastructure.Mappings;
using Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Persistence
{
    public class WriteDbContext : BaseDBContext<WriteDbContext>
    {
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        internal DbSet<Role> Roles => Set<Role>();

        internal DbSet<ClientId> ClientIds => Set<ClientId>();

        internal DbSet<ClientInformation> ClientInformations => Set<ClientInformation>();

        internal DbSet<ClientPassword> ClientPasswords => Set<ClientPassword>();

        internal DbSet<ClientRole> clientRoles => Set<ClientRole>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.ApplyConfiguration(new ClientIdConfiguration());

            modelBuilder.ApplyConfiguration(new ClientInformationConfiguration());

            modelBuilder.ApplyConfiguration(new ClientPasswordConfiguration());

            modelBuilder.ApplyConfiguration(new ClientRoleConfiguration());
        }
    }
}
