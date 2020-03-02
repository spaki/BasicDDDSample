using BasicDDDSample.Domain.Interfaces.Repositories;
using BasicDDDSample.Domain.Models;
using BasicDDDSample.Repository.EF.Common;
using BasicDDDSample.Repository.EF.Context;

namespace BasicDDDSample.Repository.EF
{
    public class OrderRepository : CrudRepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(MainDbContext context) : base(context)
        {
        }
    }
}
