using BasicDDDSample.Domain.Dtos;
using BasicDDDSample.Domain.Interfaces.Services.Common;
using BasicDDDSample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicDDDSample.Domain.Interfaces.Services
{
    public interface IOrderService : IServiceBase
    {
        List<OrderDto> List();
        List<OrderDto> List(Guid customerId);
        OrderDto GetAsync(ulong number);
        Task<Order> SaveAsync(Order entity);
    }
}
