using BasicDDDSample.Domain.Models.Common;

namespace BasicDDDSample.Domain.Models
{
    public class Product : EntityBase
    {
        public virtual decimal Price { get; set; }
        public virtual string Name { get; set; }
    }
}
