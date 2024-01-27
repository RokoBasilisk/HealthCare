using Auth.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities
{
    public class Role : EntityBase
    {
        public string RoleName { get; set; }

        public string RoleDescription {  get; set; }

        public ICollection<ClientId> ClientIds { get; set; }
    }
}
