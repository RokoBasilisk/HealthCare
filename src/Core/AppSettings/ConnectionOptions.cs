using Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AppSettings
{
    public sealed class ConnectionOptions : IAppOptions
    {
        static string IAppOptions.ConfigSectionPath => "ConnectionStrings";

        public string PostgreSqlConnection { get; private init; }

        public string CacheConnection { get; private init; }
    }
}
