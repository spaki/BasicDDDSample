using BasicDDDSample.API.Controllers.Common;
using BasicDDDSample.Domain.Dtos;
using BasicDDDSample.Domain.Interfaces.Services;
using BasicDDDSample.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicDDDSample.API.Controllers
{
    public class OrderController : PublicApiController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> Get() => Ok(orderService.List());

        [HttpGet("{number}")]
        public ActionResult<OrderDto> GetByNumber(ulong number) => Ok(orderService.GetAsync(number));

        [HttpGet("customer/{customerId}")]
        public ActionResult<IEnumerable<OrderDto>> GetByCustomer(Guid customerId) => Ok(orderService.List(customerId));

        [HttpPost]
        public async Task<ActionResult> PostAsync(Order entity) => Ok(await orderService.SaveAsync(entity));
    }
}
