using BasicDDDSample.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicDDDSample.Domain.Models
{
    public class Order : EntityBase
    {
        public virtual DateTime Created { get; private set; }
        public virtual Customer Customer { get; set; }
        public virtual bool IsPaid { get; set; }
        public virtual uint Number { get; private set; }

        public virtual List<OrderItem> Items { get; set; }

        public decimal GetTotalPrice() => Items.Sum(e => e.Product.Price * e.Quantity);

        public static Order GenerateNew()
        {
            var result = new Order
            {
                Created = DateTime.UtcNow,
                Items = new List<OrderItem>()
            };

            result.Number = BitConverter.ToUInt32(BitConverter.GetBytes(result.Created.Ticks), 0);

            return result;
        }
    }
}
