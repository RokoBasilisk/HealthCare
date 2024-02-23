using Auth.Domain.Entities.ClientAggregate;
using Auth.Domain.Entities.ClientAggregate.Enums;
using Auth.Domain.Entities.RoleAggregate;
using Auth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Factories
{
    public static class ClientInformationFactory
    {
        public static ClientInformation Create(string name, EGender gender, bool isLocked, DateTime expiredDate, ClientId client)
            => new(expiredDate, isLocked, name, gender, client);
    }
}
