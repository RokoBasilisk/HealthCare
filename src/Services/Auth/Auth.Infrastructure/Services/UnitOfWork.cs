using Auth.Infrastructure.Persistence;
using Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Auth.Infrastructure.Services
{
    internal sealed class UnitOfWork(WriteDbContext writeDbContext, ILogger<UnitOfWork> logger) : IUnitOfWork
    {
        public async Task SaveChangesAsync()
        {
            // Creating the execution strategy (Connection resiliency and database retries).
            var strategy = writeDbContext.Database.CreateExecutionStrategy();

            // Execute the strategy
            await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await writeDbContext.Database.BeginTransactionAsync();

                logger.LogInformation("----- Begin transaction: '{TransactionId}'", transaction.TransactionId);

                try
                {
                    var rowsAffected = await writeDbContext.SaveChangesAsync();

                    logger.LogInformation("----- Commit transaction: '{TransactionId}'", transaction.TransactionId);

                    await transaction.CommitAsync();

                    logger.LogInformation(
                        "----- Transaction successfully confirmed: '{TransactionId}', Rows affected: {RowsAffected}",
                        transaction.TransactionId,
                        rowsAffected);
                }
                catch (Exception ex)
                {
                    logger.LogError(
                        ex,
                        "An unexpected exception occured while committing the transaction: '{TransactionId}', message: '{message}'",
                        transaction.TransactionId,
                        ex.Message);

                    // Roll back data
                    await transaction.RollbackAsync();

                    throw;
                }
            });
        }
    }
}
