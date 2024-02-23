using Auth.Infrastructure.Persistence;
using Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositories.Common
{
    internal abstract class BaseWriteRepository<TEntity> : IWriteAsyncRepository<TEntity> where TEntity : EntityBase
    {
        private readonly DbSet<TEntity> _dbSet;
        protected readonly WriteDbContext Context;

        protected BaseWriteRepository(WriteDbContext context)
        {
            Context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Delete(TEntity entity) =>
            _dbSet.Remove(entity);

        public async Task<TEntity> GetByIdAsync(Guid id)
            => await _dbSet.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(entity => entity.Id == id);

        public void Update(TEntity entity) =>
            _dbSet.Update(entity);

        public void Add(TEntity entity) =>
            _dbSet.Add(entity);
    }
}
