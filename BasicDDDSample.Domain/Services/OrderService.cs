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

        public List<OrderDto> List(Guid customerId) => orderRepository.Query(e => e.Customer.Id == customerId).OrderByDescending(e => e.Created).ToList().Select(e => new OrderDto(e)).ToList();

        //public OrderDto GetAsync(ulong number) => orderRepository.Query(e => e.Number == number).ToList().Select(e => new OrderDto(e)).FirstOrDefault();
        public OrderDto GetAsync(ulong number)
        {
            var result = orderRepository.Query(e => e.Number == number).ToList().Select(e => new OrderDto(e)).FirstOrDefault();
            return result;
        }


        public async Task<Order> SaveAsync(Order entity) 
        {
            var original = await orderRepository.GetAsync(entity.Id);

            if (original == null)
                original = Order.GenerateNew();

            original.Customer = await customerRepository.GetAsync(entity.Customer.Id);
            await SyncProducts(original, entity);

            await orderRepository.SaveAsync(original);
            return original;
        }

        private async Task SyncProducts(Order original, Order proposal)
        {
            foreach (var proposalItem in proposal.Items)
            {
                var originalItemFound = original.Items.FirstOrDefault(originalItem => originalItem.Product.Id == proposalItem.Product.Id);

                if (originalItemFound != null) // -> update
                {
                    originalItemFound.Quantity = proposalItem.Quantity;
                }
                else // -> insert
                {
                    proposalItem.Product = await productRepository.GetAsync(proposalItem.Product.Id);
                    original.Items.Add(proposalItem);
                }
            };

            original.Items.RemoveAll(originalItem => !proposal.Items.Any(proposalItem => originalItem.Product.Id == proposalItem.Product.Id)); // -> delete
        }
    }
}
