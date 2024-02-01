using Auth.Domain.Entities;
using Auth.Domain.Entities.RoleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Factories
{
    public static class RoleFactory
    {
        public static Role Create(string roleName, string roleDescription)
            => new(roleName, roleDescription);
    }
}
