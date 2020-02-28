using System.Collections.Generic;

namespace BasicDDDSample.Domain.Models.Common
{
    public class PagedResult<TEntity>
    {
        public virtual int Page { get; set; }
        public virtual int TotalPages { get; set; }
        public virtual List<TEntity> Items { get; set; }
    }
}
