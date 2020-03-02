using BasicDDDSample.Domain.Models;
using System;
using System.Collections.Generic;

namespace BasicDDDSample.Domain.Dtos
{
    public class OrderDto
    {
        public OrderDto(Order entity)
        {
            Created = entity.Created;
            Customer = entity.Customer;
            IsPaid = entity.IsPaid;
            Items = entity.Items;
            TotalPrice = entity.GetTotalPrice();
            Number = entity.GetNumber();
        }

        public DateTime Created { get; set; }
        public Customer Customer { get; set; }
        public bool IsPaid { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public decimal TotalPrice { get; set; }
        public string Number { get; set; }
    }
}
