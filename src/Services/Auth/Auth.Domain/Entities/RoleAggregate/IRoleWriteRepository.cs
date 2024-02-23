using Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.RoleAggregate
{
    public interface IRoleWriteRepository : IWriteAsyncRepository<Role>
    {
        Task<Role> GetRoleByNameAsync(string roleName);
    }
}
