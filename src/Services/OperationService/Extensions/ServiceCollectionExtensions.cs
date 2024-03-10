using Core.AppSettings;
using Core.Extensions;
using Core.SharedKernel;
using OperationService.Service;

namespace OperationService.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCacheService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionOptions = configuration.GetOptions<ConnectionOptions>();

            return services.AddStackExchangeRedisCache(redisOptions =>
            {
                redisOptions.InstanceName = "master";
                redisOptions.Configuration = connectionOptions.CacheConnection;
            }).AddDistributedCacheService();
        }

        public static IServiceCollection AddDistributedCacheService(this IServiceCollection services) =>
            services.AddScoped<ICacheService, DistributedCacheService>();
    }
}
