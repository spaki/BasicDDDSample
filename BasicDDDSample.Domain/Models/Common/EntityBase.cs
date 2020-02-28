using System;

namespace BasicDDDSample.Domain.Models.Common
{
    public abstract class EntityBase
    {
        public virtual Guid Id { get; set; }
    }
}
