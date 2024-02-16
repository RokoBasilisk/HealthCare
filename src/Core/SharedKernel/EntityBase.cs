
namespace Core.SharedKernel
{
    public abstract class EntityBase : IEntity<Guid>
    {
        private readonly List<EventBase> _domainEvents = new();

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? LastModifiedBy { get; set; } = null;

        public DateTime? LastModifiedDate { get; set; } = null;

        public Guid Id { get; private init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBase"/> class.
        /// </summary>
        protected EntityBase() => Id = Guid.NewGuid();

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBase"/> class with the specific identifier
        /// </summary>
        /// <param name="id">The unique identifier of the entity</param>
        protected EntityBase(Guid id) => Id = id;

        /// <summary>
        /// Gets all the domain events associated with this entity
        /// </summary>
        public IEnumerable<EventBase> DomainEvents => _domainEvents.AsReadOnly();

        /// <summary>
        /// Adds a domain event to the entity
        /// </summary>
        /// <param name="domainEvent">The domain event to add</param>
        protected void AddDomainEvent(EventBase domainEvent) => _domainEvents.Add(domainEvent);

        /// <summary>
        /// Clear all the domain events associated with this entity
        /// </summary>
        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
