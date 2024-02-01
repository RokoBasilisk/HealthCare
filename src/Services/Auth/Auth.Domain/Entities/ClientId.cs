using Auth.Domain.Entities.RoleAggregate;
using Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities
{
    public class ClientId : EntityBase
    {
        public string LoginId { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}
