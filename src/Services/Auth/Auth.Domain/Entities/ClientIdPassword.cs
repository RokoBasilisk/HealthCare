﻿using Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities
{
    public class ClientIdPassword : EntityBase
    {
        public virtual ClientId ClientId { get; set; }

        public string Password { get; set; }
    }
}
