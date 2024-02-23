using Auth.Domain.Entities.ClientAggregate;
using Auth.Domain.Entities.RoleAggregate;
using Auth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Factories
{
    public static class ClientFactory
    {
        public static ClientId Create(Email email)
            => new(email);
    }
}
