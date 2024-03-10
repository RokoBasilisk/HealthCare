using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SharedKernel
{
    public interface ICacheService
    {
        /// <summary>
        /// Get an item from the cache if exist, otherwise fetch new item using the provided factory function and add
        /// it to cache
        /// </summary>
        /// <typeparam name="TItem">The type of item to get from cache or fetch new</typeparam>
        /// <param name="cacheKey">The key to identify the item in the cache</param>
        /// <param name="factory">The factory function to fetch new item</param>
        /// <returns>The item from the cache or fetch new item</returns>
        Task<TItem> GetOrCreateAsync<TItem>(string cacheKey, Func<Task<TItem>> factory);

        /// <summary>
        /// Gets a list of items from the cache if it exists, otherwise creates the items using the provided factory function and adds them to the cache.
        /// </summary>
        /// <typeparam name="TItem">The type of the items to get or create.</typeparam>
        /// <param name="cacheKey">The key to identify the items in the cache.</param>
        /// <param name="factory">The factory function to create the items if they don't exist in the cache.</param>
        /// <returns>The list of items from the cache or the newly created items.</returns>
        Task<IReadOnlyList<TItem>> GetOrCreateAsync<TItem>(string cacheKey, Func<Task<IReadOnlyList<TItem>>> factory);

        /// <summary>
        /// Removes the items with the specified cache keys from the cache.
        /// </summary>
        /// <param name="cacheKeys">The keys of the items to remove from the cache.</param>
        /// <returns>A task representing the asynchronous removal operation.</returns>
        Task RemoveAsync(params string[] cacheKeys);

        /// <summary>
        /// Set cacheKey with value to cache
        /// </summary>
        /// <param name="cacheKey">The key to identify the items in the cache.</param>
        /// <param name="value">The value to add to cache</param>
        /// <returns></returns>
        Task<bool> SetAsync(string cacheKey, string value);
    }
}
