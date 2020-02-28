using BasicDDDSample.Domain.Models.Common;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BasicDDDSample.Domain.Interfaces.Repositories.Common
{
    public interface ICrudRepositoryBase<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> GetAsync(Guid id);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task SubmitChangeAsync(TEntity entity);
        void DeleteNoCommit(TEntity entity);
        Task CommitChangesAsync();
        Task SaveAsync(TEntity entity);
        Task DeleteAsync(Guid id);
        IQueryable<TEntity> Query();
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate);
    }
}
