using Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.ClientAggregate
{
    public class ClientPassword : EntityBase
    {
        public Guid ClientId { get; }
        public byte[] Password { get; }
        public byte[] PasswordSalt { get; }

        public virtual ClientId Client { get; set; }

        public ClientPassword(byte[] password, byte[] passwordSalt, ClientId client)
        {
            Password = password;
            PasswordSalt = passwordSalt;
            ClientId = client.Id;
        }

        public ClientPassword() {}
    }
}
