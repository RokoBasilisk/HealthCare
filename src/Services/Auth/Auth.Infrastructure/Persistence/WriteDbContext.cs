using Auth.Domain.Entities.RoleAggregate;
using Auth.Infrastructure.Mappings;
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
        public WriteDbContext(DbContextOptions options) : base(options)
        {
        }

        internal DbSet<Role> Roles => Set<Role>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
