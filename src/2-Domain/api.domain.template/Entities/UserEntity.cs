﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.domain.template.Entities
{
    public class UserEntity : BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
