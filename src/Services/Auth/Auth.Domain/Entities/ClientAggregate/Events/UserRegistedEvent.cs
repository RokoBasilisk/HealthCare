using Auth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.ClientAggregate.Events
{
    public class UserRegistedEvent : ClientIdBaseEvent
    {
        public UserRegistedEvent(Guid id, Email email) : base(id, email)
        {
        }
    }
}
