using BasicDDDSample.Domain.Models;
using System;

namespace BasicDDDSample.Domain.Dtos
{
    public class CustomerDto
    {
        public CustomerDto(Customer entity)
        {
            Id = entity.Id;
            Email = entity.Email;
            Name = entity.Name;
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
