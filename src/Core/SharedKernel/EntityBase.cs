
namespace Core.SharedKernel
{
    public abstract class EntityBase : IEntity<Guid>
    {

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

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
    }
}
