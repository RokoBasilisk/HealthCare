﻿using Auth.Domain.Entities.RoleAggregate;
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
    internal class RoleWriteRepository : BaseWriteRepository<Role>, IRoleWriteRepository
    {
        public RoleWriteRepository(WriteDbContext context) : base(context)
        {
        }

        public Task<Role> GetRoleByNameAsync(string roleName)
            => Context.Roles
                .SingleOrDefaultAsync(role => role.RoleName == roleName);
    }
}
