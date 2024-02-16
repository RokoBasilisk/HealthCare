using Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.RoleAggregate.Events
{
    public abstract class RoleBaseEvent : EventBase
    {
        protected RoleBaseEvent(Guid id, string roleName, string roleDescription)
        {
            Id = id;
            RoleName = roleName;
            RoleDescription = roleDescription;
        }

        public Guid Id { get; private init; }

        public string RoleName { get; private init; }

        public string RoleDescription { get; private init; }
    }
}
