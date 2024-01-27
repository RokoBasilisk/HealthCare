using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Persistence
{
    public class BaseDBContext<TContext> : DbContext
        where TContext : DbContext
    {
        private const string Collation = "Latin1_General_CI_AI";
    }
}
