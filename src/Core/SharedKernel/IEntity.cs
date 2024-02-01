using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SharedKernel
{
    /// <summary>
    /// This is the base interface for all entities
    /// </summary>
    public interface IEntity
    {
    }
    public interface IEntity<out TKey> : IEntity where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Get The ID of the entity
        /// </summary>
        TKey Id { get; }
    }
}
