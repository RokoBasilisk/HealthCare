using Auth.Domain.Entities.ClientAggregate;
using Auth.Domain.Entities.RoleAggregate;
using Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.EntityAggregate
{
    public class ClientRole
    {
        public Guid ClientId { get; set; }
        public Guid RoleId { get; set; }
        public virtual ClientId Client { get; set; }
        public virtual Role Role { get; set; }
        public ClientRole() { }

        public ClientRole(Guid clientId, Guid roleId)
        {
            ClientId = clientId;
            RoleId = roleId;
        }
    }
}
