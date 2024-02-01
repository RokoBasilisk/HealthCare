using Core.SharedKernel;

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
        }

        public string RoleName { get; set; }

        public string RoleDescription { get; set; }

        public ICollection<ClientId> ClientIds { get; set; }
    }
}
