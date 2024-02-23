using Auth.Domain.ValueObjects;
using Core.Extensions;
using Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.ClientAggregate.Events
{
    public abstract class ClientIdBaseEvent : EventBase
    {
        protected ClientIdBaseEvent(Guid id, Email email)
        {
            Id = id;
            AggregateId = id;
            MessageType = this.GetGenericTypeName();
            Email = email;
        }

        public Guid Id { get; private init; }

        public Email Email { get; private init; }
    }
}
