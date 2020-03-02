using BasicDDDSample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicDDDSample.Domain.Dtos
{
    public class OrderDto
    {
        public OrderDto(Order entity)
        {
            Id = entity.Id;
            Created = entity.Created;
            Customer = new CustomerDto(entity.Customer);
            IsPaid = entity.IsPaid;
            Number = entity.Number;
            Items = entity.Items.Select(e => new OrderItemDto(e)).ToList();
            TotalPrice = entity.GetTotalPrice();
        }

        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public CustomerDto Customer { get; set; }
        public bool IsPaid { get; set; }

        public List<OrderItemDto> Items { get; set; }

        public decimal TotalPrice { get; set; }
        public ulong Number { get; set; }
    }
}
