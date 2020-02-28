using BasicDDDSample.Domain.Models.Common;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BasicDDDSample.Domain.Interfaces.Services.Common
{
    public interface ICrudServiceBase<TEntity> : IServiceBase where TEntity : EntityBase
    {
        Task<TEntity> GetAsync(Guid id);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task SaveAsync(TEntity entity);
        Task SubmitChangeAsync(TEntity entity);
        void DeleteNoCommit(TEntity entity);
        Task CommitChangesAsync();
        Task DeleteAsync(Guid id);
        bool Any(Guid id);
        bool Any(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Query();
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate);
        PagedResult<TEntity> Page(IQueryable<TEntity> query, int page, int pageSize = 10);
        PagedResult<TEntity> Page(Expression<Func<TEntity, bool>> predicate, int page, int pageSize = 10);
    }
}
