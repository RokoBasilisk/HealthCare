using Auth.Infrastructure.Persistence;
using Core.AppSettings;
using Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Auth.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServicesCollectionExtensions
    {
        private const string MigrationsAssembly = "Auth.API";

        public static IServiceCollection AddWriteDbContext(this IServiceCollection services) =>
            services.AddDbContext<WriteDbContext>((serviceProvider, optionsBuilder) =>
                ConfigureDbContext<WriteDbContext>(serviceProvider, optionsBuilder, QueryTrackingBehavior.TrackAll));
        private static void ConfigureDbContext<TContext>(
            IServiceProvider serviceProvider,
            DbContextOptionsBuilder optionsBuilder,
            QueryTrackingBehavior queryTrackingBehavior) where TContext : DbContext
        {
            var logger = serviceProvider.GetRequiredService<ILogger<TContext>>();
            var connectionOptions = serviceProvider.GetOptions<ConnectionOptions>();

            optionsBuilder.UseNpgsql(connectionOptions.PostgreSqlConnection, options =>
                options
                    .MigrationsAssembly(MigrationsAssembly)
                    .EnableRetryOnFailure(3)
                    .CommandTimeout(60))
                .UseQueryTrackingBehavior(queryTrackingBehavior);
        }
    }
}
