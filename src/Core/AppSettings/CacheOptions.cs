using Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AppSettings
{
    public sealed class CacheOptions : IAppOptions
    {
        public static string ConfigSectionPath => nameof(CacheOptions);

        public int AbsoluteExpirationInHours { get; private init; }

        public int SlidingExpirationInSeconds { get; private init; }
    }
}
