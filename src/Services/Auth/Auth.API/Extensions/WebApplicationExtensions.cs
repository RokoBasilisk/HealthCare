using Auth.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Runtime.CompilerServices;

namespace Auth.API.Extensions
{
    internal static class WebApplicationExtensions
    {
        public static async Task MigrationDbAsync(this WebApplication app, AsyncServiceScope serviceScope)
        {
            await using var writeDbContext = serviceScope.ServiceProvider.GetService<WriteDbContext>();
            await using var eventStoreDbContext = serviceScope.ServiceProvider.GetService<EventStoreDbContext>();

            try
            {
                await app.MigrationDbContextAsync(writeDbContext);
                await app.MigrationDbContextAsync(eventStoreDbContext);
            }
            catch (Exception ex)
            {
                app.Logger.LogError(ex, "An exception occurred while initializing the application: {Message}", ex.Message);
                throw;
            }
        }

        private static async Task MigrationDbContextAsync<TContext>(this WebApplication app, TContext context)
            where TContext : DbContext
        {
            var dbName = context.Database.GetDbConnection().Database;

            app.Logger.LogInformation("---- {DbName}: {DbConnection}", dbName, context.Database.GetConnectionString());
            app.Logger.LogInformation("---- {DbName}: Checking if there any pending migrations...", dbName);

            if ((await context.Database.GetPendingMigrationsAsync()).Any())
            {
                app.Logger.LogInformation("----- {DbName}: creating and migrating the database...", dbName);

                await context.Database.MigrateAsync();

                app.Logger.LogInformation("----- {DbName}: database was created and migrated successfully", dbName);
            }
            else
            {
                app.Logger.LogInformation("----- {DbName}: all migrations are up to date", dbName);
            }
        }
    }
}
