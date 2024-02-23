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
    public static class ClientPasswordFactory
    {
        public static ClientPassword Create(byte[] password, byte[] passwordSalt, ClientId client)
            => new(password, passwordSalt, client);
    }
}
