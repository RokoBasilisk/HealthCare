using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.SharedKernel
{
    public interface IWriteAsyncRepository<TEntity> where TEntity : IEntity<Guid>
    {

        /// <summary>
        /// Retrieve an entity from repository with specific id
        /// </summary>
        /// <param name="id">Identifier of an entity</param>
        /// <returns>An entity</returns>
        Task<TEntity> GetByIdAsync(Guid id);

        /// <summary>
        /// Create an entity to the repository
        /// </summary>
        /// <param name="entity">An entity for saved</param>
        void Add(TEntity entity);

        /// <summary>
        /// Updates an entity in the repository
        /// </summary>
        /// <param name="entity">An entity for modified</param>
        void Update(TEntity entity);

        /// <summary>
        /// Removes an entity from the repository
        /// </summary>
        /// <param name="entity">An entity for removed</param>
        void Delete(TEntity entity);
    }
}
