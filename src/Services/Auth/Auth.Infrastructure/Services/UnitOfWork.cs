using Auth.Infrastructure.Persistence;
using Core.Extensions;
using Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Auth.Infrastructure.Services
{
    internal sealed class UnitOfWork(WriteDbContext _writeDbContext, ILogger<UnitOfWork> logger) : IUnitOfWork
    {
        public async Task SaveChangesAsync()
        {
            // Creating the execution strategy (Connection resiliency and database retries).
            var strategy = _writeDbContext.Database.CreateExecutionStrategy();

            // Execute the strategy
            await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _writeDbContext.Database.BeginTransactionAsync();

                logger.LogInformation("----- Begin transaction: '{TransactionId}'", transaction.TransactionId);

                try
                {
                    var domainEntities = _writeDbContext.ChangeTracker.Entries<EntityBase>().Where(entry => entry.Entity.DomainEvents.Any());
                    //var (domainEvents, eventStores) = BeforeSaveChanges();

                    var rowsAffected = await _writeDbContext.SaveChangesAsync();

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

        //private (IReadOnlyList<EventBase> domainEvents, IReadOnlyList<EventStore> eventStores) BeforeSaveChanges()
        //{
        //    // Get all domain entities with pending domain events
        //    var domainEntities = _writeDbContext
        //        .ChangeTracker
        //        .Entries<EntityBase>()
        //        .Where(entry => entry.Entity.DomainEvents.Any())
        //        .ToList();
            
        //    // Get all domain events from entities
        //    var domainEvents = domainEntities
        //        .SelectMany(entry => entry.Entity.DomainEvents)
        //        .ToList();

        //    var eventStores = domainEvents
        //        .ConvertAll(@event => new EventStore(@event.AggregateId, @event.GetGenericTypeName(), @event.ToJson()));

        //    // Clear domain events from the entities
        //    domainEntities.ForEach(entry => entry.Entity.ClearDomainEvents());

        //    return (domainEvents, eventStores);
        //}
    }
}
