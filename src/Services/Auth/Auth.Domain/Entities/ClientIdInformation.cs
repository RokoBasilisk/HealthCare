﻿using Auth.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities
{
    public class ClientIdInformation : EntityBase
    {
        public virtual ClientId ClientId { get; set; }
    }
}