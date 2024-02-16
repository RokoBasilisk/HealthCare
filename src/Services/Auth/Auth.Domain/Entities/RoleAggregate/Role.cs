using Auth.Domain.Entities.RoleAggregate.Events;
using Core.SharedKernel;
using System.ComponentModel.DataAnnotations;

namespace Auth.Domain.Entities.RoleAggregate
{
    public class Role : EntityBase
    {
        public Role()
        {
        }

        public Role(string roleName, string roleDescription)
        {
            RoleName = roleName;
            RoleDescription = roleDescription;

            AddDomainEvent(new RoleCreatedEvent(Id, RoleName, RoleDescription));
        }

        public string RoleName { get; set; }

        public string RoleDescription { get; set; }

        [Timestamp]
        public byte[] Version {  get; set; }

        public ICollection<ClientId> ClientIds { get; set; }
    }
}
