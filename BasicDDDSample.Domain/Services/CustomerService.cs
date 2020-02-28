using BasicDDDSample.Domain.Interfaces.Repositories;
using BasicDDDSample.Domain.Interfaces.Repositories.Common;
using BasicDDDSample.Domain.Interfaces.Services;
using BasicDDDSample.Domain.Models;
using BasicDDDSample.Domain.Services.Common;

namespace BasicDDDSample.Domain.Services
{
    public class CustomerService : CrudServiceBase<Customer>, ICustomerService
    {
        public CustomerService(ICustomerRepository repository) : base(repository)
        {
        }
    }
}
