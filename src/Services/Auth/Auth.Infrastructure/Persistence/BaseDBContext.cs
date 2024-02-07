using Auth.Infrastructure.Extensions;
using Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Auth.Infrastructure.Persistence
{
    public abstract class BaseDBContext<TContext> : DbContext
        where TContext : DbContext
    {
        private const string Collation = "en-LC";

        public BaseDBContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder
                //.UseCollation(Collation)
                .RemoveCascadeDeleteConvension();
            base.OnModelCreating(modelBuilder);
        }

        public override ChangeTracker ChangeTracker
        {
            get
            {
                base.ChangeTracker.LazyLoadingEnabled = false;
                base.ChangeTracker.CascadeDeleteTiming = CascadeTiming.OnSaveChanges;
                base.ChangeTracker.DeleteOrphansTiming = CascadeTiming.OnSaveChanges;
                return base.ChangeTracker;
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "nghia";
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "nghia";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
