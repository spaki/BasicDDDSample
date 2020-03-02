using BasicDDDSample.Domain.Interfaces.Repositories;
using BasicDDDSample.Domain.Interfaces.Services;
using BasicDDDSample.Domain.Models;
using BasicDDDSample.Domain.Services.Common;

namespace BasicDDDSample.Domain.Services
{
    public class ProductService : CrudServiceBase<Product>, IProductService
    {
        public ProductService(IProductRepository repository) : base(repository)
        {
        }
    }
}
