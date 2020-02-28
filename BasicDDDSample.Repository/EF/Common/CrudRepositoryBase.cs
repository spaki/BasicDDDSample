using BasicDDDSample.Domain.Interfaces.Repositories.Common;
using BasicDDDSample.Domain.Models.Common;
using BasicDDDSample.Repository.Common;
using BasicDDDSample.Repository.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BasicDDDSample.Repository.EF.Common
{
    public abstract class CrudRepositoryBase<TEntity> : RepositoryBase, ICrudRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected MainDbContext context;
        protected DbSet<TEntity> set;

        public CrudRepositoryBase(MainDbContext context)
        {
            this.context = context;
            this.set = this.context.Set<TEntity>();
        }

        public async Task CommitChangesAsync() => await this.context.SaveChangesAsync();

        public async Task DeleteAsync(Guid id)
        {
            var entity = await this.GetAsync(id);

            if (entity == null)
                return;

            set.Remove(entity);
            await CommitChangesAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) => await this.Query().FirstOrDefaultAsync(predicate);

        public async Task<TEntity> GetAsync(Guid id) => await FirstOrDefaultAsync(e => e.Id == id);

        public IQueryable<TEntity> Query() => set.AsQueryable();

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate) => set.Where(predicate);

        public void DeleteNoCommit(TEntity entity) => set.Remove(entity);

        public async Task SaveAsync(TEntity entity)
        {
            if (entity.Id == null || entity.Id == Guid.Empty)
                await set.AddAsync(entity);
            else
                context.Entry(entity).State = EntityState.Modified;

            await CommitChangesAsync();
        }

        public async Task SubmitChangeAsync(TEntity entity)
        {
            if (entity.Id == null || entity.Id == Guid.Empty)
                await set.AddAsync(entity);
            else
                context.Entry(entity).State = EntityState.Modified;
        }
    }
}
