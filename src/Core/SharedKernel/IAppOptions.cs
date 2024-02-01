using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SharedKernel
{
    public interface IAppOptions
    {
        static abstract string ConfigSectionPath { get; }
    }
}
