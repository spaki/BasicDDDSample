using BasicDDDSample.API.Controllers.Common;
using BasicDDDSample.Domain.Interfaces.Services;
using BasicDDDSample.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicDDDSample.API.Controllers
{
    public class ProductController : PublicApiController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get() => Ok(productService.Query());

        [HttpPost]
        public async Task<ActionResult> PostAsync(Product entity)
        {
            await productService.SaveAsync(entity);
            return Ok();
        }
    }
}
