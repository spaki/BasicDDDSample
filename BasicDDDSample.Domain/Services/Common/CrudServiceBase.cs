using BasicDDDSample.Domain.Interfaces.Repositories.Common;
using BasicDDDSample.Domain.Interfaces.Services.Common;
using BasicDDDSample.Domain.Models.Common;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BasicDDDSample.Domain.Services.Common
{
    public abstract class CrudServiceBase<TEntity> : ServiceBase, ICrudServiceBase<TEntity> where TEntity : EntityBase
    {
        public const int DefaultPageSize = 10;

        protected ICrudRepositoryBase<TEntity> repository;

        public CrudServiceBase(ICrudRepositoryBase<TEntity> repository) => this.repository = repository;

        public bool Any(Guid id) => Query().Any(e => e.Id.Equals(id));

        public bool Any(Expression<Func<TEntity, bool>> predicate) => Query().Any(predicate);

        public async Task CommitChangesAsync() => await this.repository.CommitChangesAsync();

        public async Task DeleteAsync(Guid id) => await repository.DeleteAsync(id);

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) => await repository.FirstOrDefaultAsync(predicate);

        public async Task<TEntity> GetAsync(Guid id) => await repository.GetAsync(id);

        public virtual PagedResult<TEntity> Page(Expression<Func<TEntity, bool>> predicate, int page, int pageSize = DefaultPageSize) => this.Page(this.Query(predicate), page, pageSize);

        public virtual PagedResult<TEntity> Page(IQueryable<TEntity> query, int page, int pageSize = DefaultPageSize)
        {
            var totalItems = query.Count();
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var startIndex = ((page - 1) * pageSize);
            var items = query.Skip(startIndex).Take(pageSize).ToList();

            var result = new PagedResult<TEntity>
            {
                Items = items,
                Page = page,
                TotalPages = totalPages
            };

            return result;
        }

        public IQueryable<TEntity> Query() => repository.Query();

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate) => repository.Query(predicate);

        public void DeleteNoCommit(TEntity entity) => this.repository.DeleteNoCommit(entity);

        public async Task SaveAsync(TEntity entity) => await repository.SaveAsync(entity);

        public async Task SubmitChangeAsync(TEntity entity) => await this.repository.SubmitChangeAsync(entity);
    }
}
