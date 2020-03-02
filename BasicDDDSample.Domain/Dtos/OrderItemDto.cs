using BasicDDDSample.Domain.Models;
using System;

namespace BasicDDDSample.Domain.Dtos
{
    public class OrderItemDto
    {
        public OrderItemDto(OrderItem entity)
        {
            Id = entity.Id;
            Product = new ProductDto(entity.Product);
            Quantity = entity.Quantity;
        }

        public Guid Id { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}