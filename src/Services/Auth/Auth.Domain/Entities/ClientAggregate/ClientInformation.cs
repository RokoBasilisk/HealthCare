using Auth.Domain.Entities.ClientAggregate.Enums;
using Auth.Domain.ValueObjects;
using Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.ClientAggregate
{
    public class ClientInformation : EntityBase
    {
        public Guid ClientId { get; }

        public DateTime ExpiredDate { get; }

        public bool IsLocked { get; }

        public string Name { get; }

        public EGender Gender { get; }

        public virtual ClientId Client { get; set; }

        public ClientInformation(DateTime expiredDate, bool isLocked, string name, EGender gender, ClientId client)
        {
            ExpiredDate = expiredDate;
            IsLocked = isLocked;
            Name = name;
            Gender = gender;
            ClientId = client.Id;
        }

        public ClientInformation() { }
    }
}
