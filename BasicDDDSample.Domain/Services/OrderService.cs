using BasicDDDSample.Domain.Dtos;
using BasicDDDSample.Domain.Interfaces.Repositories;
using BasicDDDSample.Domain.Interfaces.Services;
using BasicDDDSample.Domain.Models;
using BasicDDDSample.Domain.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicDDDSample.Domain.Services
{
    public class OrderService : ServiceBase, IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IProductRepository productRepository;

        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.customerRepository = customerRepository;
            this.productRepository = productRepository;
        }

        public List<OrderDto> List() => orderRepository.Query().OrderByDescending(e => e.Created).ToList().Select(e => new OrderDto(e)).ToList();

        public List<OrderDto> List(Guid customerId) => orderRepository.Query(e => e.Customer.Id == customerId).OrderByDescending(e => e.Created).Select(e => new OrderDto(e)).ToList();

        public OrderDto GetAsync(Guid id) => orderRepository.Query(e => e.Id == id).Select(e => new OrderDto(e)).FirstOrDefault();


        public async Task<Order> SaveAsync(Order entity) 
        {
            if(entity.IsNew())
                entity.Created = DateTime.UtcNow;
            
            entity.Customer = await customerRepository.GetAsync(entity.Customer.Id);

            for (int i = 0; i < entity.Items.Count; i++)
            {
                var item = entity.Items[i];
                item.Product = await productRepository.GetAsync(item.Product.Id);
            }

            await orderRepository.SaveAsync(entity);
            return entity;
        }
    }
}
