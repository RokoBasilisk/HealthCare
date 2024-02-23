using Auth.Domain.Entities.RoleAggregate;
using Auth.Domain.ValueObjects;
using Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.ClientAggregate
{
    public interface IClientWriteRepository : IWriteAsyncRepository<ClientId>
    {
        Task<bool> ExistsAsync(Email id);
    }

}
