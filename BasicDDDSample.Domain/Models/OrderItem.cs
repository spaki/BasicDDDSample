using BasicDDDSample.Domain.Models.Common;

namespace BasicDDDSample.Domain.Models
{
    public class OrderItem : EntityBase
    {
        public virtual Product Product { get; set; }
        public virtual int Quantity { get; set; }
    }
}
