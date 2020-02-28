using BasicDDDSample.Domain.Interfaces.Repositories;
using BasicDDDSample.Domain.Models;
using BasicDDDSample.Repository.EF.Common;
using BasicDDDSample.Repository.EF.Context;

namespace BasicDDDSample.Repository.EF
{
    public class CustomerRepository : CrudRepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(MainDbContext context) : base(context)
        {
        }
    }
}
