using BasicDDDSample.API.Controllers.Common;
using BasicDDDSample.Domain.Interfaces.Services;
using BasicDDDSample.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicDDDSample.API.Controllers
{
    public class CustomerController : PublicApiController
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get() => Ok(customerService.Query());

        [HttpPost]
        public async Task<ActionResult> PostAsync(Customer entity)
        {
            await customerService.SaveAsync(entity);
            return Ok();
        }
    }
}
