using Core.AppSettings;
using Core.Extensions;
using Core.SharedKernel;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System.Text;

namespace OperationService.Service
{
    public class DistributedCacheService : ICacheService
    {
        private const string CacheServiceName = nameof(DistributedCacheService);

        private readonly DistributedCacheEntryOptions _cacheOptions;

        private readonly IDistributedCache _distributedCache;

        private readonly ILogger<DistributedCacheService> _logger;

        public DistributedCacheService(
            IOptions<CacheOptions> cacheOptions,
            IDistributedCache distributedCache,
            ILogger<DistributedCacheService> logger)
        {
            _distributedCache = distributedCache;
            _logger = logger;
            _cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(cacheOptions.Value.AbsoluteExpirationInHours),
                //SlidingExpiration = TimeSpan.FromSeconds(cacheOptions.Value.SlidingExpirationInSeconds)
            };
        }

        public async Task<TItem> GetOrCreateAsync<TItem>(string cacheKey, Func<Task<TItem>> factory)
        {
            var valueBytes = await _distributedCache.GetAsync(cacheKey);
            if ( valueBytes?.Length > 0 )
            {
                _logger.LogInformation("----- Fetched from {CacheServiceName}: '{CacheKey}'", CacheServiceName, cacheKey);

                var value = Encoding.UTF8.GetString(valueBytes);
                return value.FromJson<TItem>();
            }

            var item = await factory();
            if ( item is null )
            {
                _logger.LogInformation("----- Added to {CacheServiceName}: '{CacheKey}'", CacheServiceName, cacheKey);

                var value = Encoding.UTF8.GetBytes(item.ToJson());
                await _distributedCache.SetAsync(cacheKey, value, _cacheOptions);
            }

            return item;
        }

        public async Task<IReadOnlyList<TItem>> GetOrCreateAsync<TItem>(string cacheKey, Func<Task<IReadOnlyList<TItem>>> factory)
        {
            var valueBytes = await _distributedCache.GetAsync(cacheKey);
            if (valueBytes?.Length > 0)
            {
                _logger.LogInformation("----- Fetched from {CacheServiceName}: '{CacheKey}'", CacheServiceName, cacheKey);

                var values = Encoding.UTF8.GetString(valueBytes);
                return values.FromJson<IReadOnlyList<TItem>>();
            }

            var items = await factory();
            if (items?.Any() == true)
            {
                _logger.LogInformation("----- Added to {CacheServiceName}: '{CacheKey}'", CacheServiceName, cacheKey);

                var value = Encoding.UTF8.GetBytes(items.ToJson());
                await _distributedCache.SetAsync(cacheKey, value, _cacheOptions);
            }

            return items;
        }

        public async Task RemoveAsync(params string[] cacheKeys)
        {
            foreach (var cacheKey in cacheKeys)
            {
                _logger.LogInformation("----- Removed from {CacheServiceName}: '{CacheKey}'", CacheServiceName, cacheKey);
                await _distributedCache.RemoveAsync(cacheKey);
            }
        }

        public async Task<bool> SetAsync(string cacheKey, string value)
        {

            if (value is not null)
            {
                var _value = Encoding.UTF8.GetBytes(value);
                await _distributedCache.SetAsync(cacheKey, _value, _cacheOptions);
                _logger.LogInformation("----- Added to {CacheServiceName}: '{CacheKey}'", CacheServiceName, cacheKey);
                return true;
            }

            _logger.LogInformation("----- Failed to Add to {CacheServiceName}: '{CacheKey}'", CacheServiceName, cacheKey);

            return false;
        }
    }
}
