using BasicDDDSample.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicDDDSample.Domain.Models
{
    public class Order : EntityBase
    {
        public virtual DateTime Created { get; set; } = DateTime.UtcNow;
        public virtual Customer Customer { get; set; }
        public virtual bool IsPaid { get; set; }

        public virtual List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public decimal GetTotalPrice() => Items.Sum(e => e.Product.Price * e.Quantity);
        public string GetNumber() => Convert.ToBase64String(BitConverter.GetBytes(Created.Ticks));

        public bool IsNew() => Id == Guid.Empty;
    }
}
