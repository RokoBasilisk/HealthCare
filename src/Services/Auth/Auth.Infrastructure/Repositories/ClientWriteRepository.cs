using Auth.Domain.Entities.ClientAggregate;
using Auth.Domain.ValueObjects;
using Auth.Infrastructure.Persistence;
using Auth.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositories
{
    internal class ClientWriteRepository : BaseWriteRepository<ClientId>, IClientWriteRepository
    {
        public ClientWriteRepository(WriteDbContext context) : base(context)
        {
        }

        public Task<bool> ExistsAsync(Email email)
        {
            return Context.ClientIds
                .AsNoTracking()
                .AnyAsync(client => client.Email.Address == email.Address);
        }
    }
}
