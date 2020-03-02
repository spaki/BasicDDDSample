﻿using BasicDDDSample.Domain.Models.Common;

namespace BasicDDDSample.Domain.Models
{
    public class Customer : EntityBase
    {
        public virtual string Email { get; set; }
        public virtual string Name { get; set; }
    }
}
