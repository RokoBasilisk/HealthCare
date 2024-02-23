using Auth.Domain.Entities.ClientAggregate.Events;
using Auth.Domain.Entities.EntityAggregate;
using Auth.Domain.Entities.RoleAggregate;
using Auth.Domain.ValueObjects;
using Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.ClientAggregate
{
    public class ClientId : EntityBase
    {
        public Email Email { get; set; }

        public Guid ClientInformationId { get; set; }

        public Guid ClientPasswordId { get; set; }

        public virtual ClientInformation ClientInformation { get; set; }

        public virtual ClientPassword ClientPassword { get; set; }

        public ICollection<ClientRole> clientRoles { get; set; }

        public ClientId(Email email)
        {
            Email = email;
            AddDomainEvent(new UserRegistedEvent(Id, Email));
        }

        public ClientId() {}
    }
}
