using BasicDDDSample.Domain.Models;
using System;

namespace BasicDDDSample.Domain.Dtos
{
    public class ProductDto
    {
        public ProductDto(Product entity)
        {
            Id = entity.Id;
            Price = entity.Price;
            Name = entity.Name;
        }

        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}
