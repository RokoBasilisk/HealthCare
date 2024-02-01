using Auth.Infrastructure.Persistence;
using Core.SharedKernel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Auth.Infrastructure.Services
{
    internal sealed class UnitOfWork(WriteDbContext writeDbContext, ILogger<UnitOfWork> logger) : IUnitOfWork
    {
        public async Task SaveChangesAsync()
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
        }
    }
}
