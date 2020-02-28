using BasicDDDSample.Domain.Interfaces.Repositories.Common;
using BasicDDDSample.Domain.Models;

namespace BasicDDDSample.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : ICrudRepositoryBase<Customer>
    {
    }
}
