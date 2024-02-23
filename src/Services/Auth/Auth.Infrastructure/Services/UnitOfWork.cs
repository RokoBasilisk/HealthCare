using Auth.Infrastructure.Persistence;
using Core.Extensions;
using Core.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Auth.Infrastructure.Services
{
    internal sealed class UnitOfWork(
        WriteDbContext writeDbContext,
        ILogger<UnitOfWork> logger,
        IEventStoreRepository eventStoreRepository,
        IMediator mediator
        ) : IUnitOfWork
    {
        private readonly WriteDbContext _writeDbContext = writeDbContext;
        private readonly IEventStoreRepository _eventStoreRepository = eventStoreRepository;
        private readonly ILogger<UnitOfWork> _logger = logger;
        private readonly IMediator _mediator = mediator;

        public async Task SaveChangesAsync()
        {
            // Creating the execution strategy (Connection resiliency and database retries).
            var strategy = _writeDbContext.Database.CreateExecutionStrategy();

            // Execute the strategy
            await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _writeDbContext.Database.BeginTransactionAsync();

                _logger.LogInformation("----- Begin transaction: '{TransactionId}'", transaction.TransactionId);

                try
                {
                    var domainEntities = _writeDbContext.ChangeTracker.Entries<EntityBase>().Where(entry => entry.Entity.DomainEvents.Any());
                    var (domainEvents, eventStores) = BeforeSaveChanges();

                    var rowsAffected = await _writeDbContext.SaveChangesAsync();

                    _logger.LogInformation("----- Commit transaction: '{TransactionId}'", transaction.TransactionId);

                    await transaction.CommitAsync();

                    // Triggering the events and saving the stores.
                    await AfterSaveChangesAsync(domainEvents, eventStores);

                    _logger.LogInformation(
                        "----- Transaction successfully confirmed: '{TransactionId}', Rows affected: {RowsAffected}",
                        transaction.TransactionId,
                        rowsAffected);
                }
                catch (Exception ex)
                {
                    _logger.LogError(
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

        private (IReadOnlyList<EventBase> domainEvents, IReadOnlyList<EventStore> eventStores) BeforeSaveChanges()
        {
            // Get all domain entities with pending domain events
            var domainEntities = _writeDbContext
                .ChangeTracker
                .Entries<EntityBase>()
                .Where(entry => entry.Entity.DomainEvents.Any())
                .ToList();

            // Get all domain events from entities
            var domainEvents = domainEntities
                .SelectMany(entry => entry.Entity.DomainEvents)
                .ToList();

            foreach (var domainEvent in domainEvents)
            {
                _logger.LogInformation("domainEvents data: {json}", domainEvent.ToJson());
            }

            var eventStores = domainEvents
                .ConvertAll(@event => new EventStore(@event.AggregateId, @event.GetGenericTypeName(), @event.ToJson()));

            // Clear domain events from the entities
            domainEntities.ForEach(entry => entry.Entity.ClearDomainEvents());

            return (domainEvents, eventStores);
        }

        private async Task AfterSaveChangesAsync(
            IReadOnlyList<EventBase> domainEvents,
            IReadOnlyList<EventStore> eventStores)
        {
            // If there are no domain events or event stores, return without performing any actions.
            if (!domainEvents.Any() || !eventStores.Any())
                return;

            // Publish each domain event in parallel using _mediator.
            var tasks = domainEvents
                .AsParallel()
                .Select(@event => _mediator.Publish(@event))
                .ToList();

            // Wait for all the published events to be processed.
            await Task.WhenAll(tasks);

            await _eventStoreRepository.StoreAsync(eventStores);
        }
    }
}
