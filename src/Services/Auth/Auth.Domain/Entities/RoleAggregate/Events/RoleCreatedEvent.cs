using Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.RoleAggregate.Events
{
    public class RoleCreatedEvent : RoleBaseEvent
    {
        public RoleCreatedEvent(Guid id, string roleName, string roleDescription) : base(id, roleName, roleDescription)
        {
        }
    }
}
