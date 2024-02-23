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
    public class EventStoreDbContext : BaseDBContext<EventStoreDbContext>
    {
        public EventStoreDbContext(DbContextOptions<EventStoreDbContext> options) : base(options)
        {
        }

        internal DbSet<EventStore> EventStores => Set<EventStore>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EventStoreConfiguration());
        }
    }
}
