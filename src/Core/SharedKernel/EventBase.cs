using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SharedKernel
{
    /// <summary>
    /// Represents a base event
    /// </summary>
    public class EventBase : INotification
    {
        /// <summary>
        /// Gets the type of the message.
        /// </summary>
        public string MessageType { get; protected init; }

        /// <summary>
        /// Gets the aggregate Id.
        /// </summary>
        [Key]
        public Guid AggregateId { get; protected init; }

        /// <summary>
        /// Gets the date and time when the event occurred
        /// </summary>
        public DateTime OccurredOn { get; protected init; } = DateTime.Now;
    }
}
