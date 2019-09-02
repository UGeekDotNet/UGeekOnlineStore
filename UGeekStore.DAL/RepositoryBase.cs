using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Infrastructre.EntityAbstraction;
using UGeekStore.Core.Infrastructre.RepositoryAbstraction;

namespace UGeekStore.DAL
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
            where TEntity : EntityBase, new()
    {
        protected readonly StoreContext Context;

        public RepositoryBase(StoreContext _context)
        {
            Context = _context;
        }

        public TEntity Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            return entity;
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
            return entities;
        }

        public void Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public void DeleteWhere(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = Context.Set<TEntity>().Where(predicate);

            foreach (var entity in entities)
            {
                Context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> sortBy = null, int? skip = null, int? take = null)
        {
            var query = Context.Set<TEntity>().Where(predicate);

            if (sortBy != null)
                query = query.OrderBy(sortBy);

            if (take.HasValue)
                query = query.Take(take.Value);
            if (skip.HasValue)
                query = query.Skip(skip.Value);

            return query.ToListAsync();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return Context.Set<TEntity>().ToListAsync();
        }

        public Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
                return Context.Set<TEntity>().Where(filter).CountAsync();
            else
                return Context.Set<TEntity>().CountAsync();
        }

        public Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public Task<bool> IfAnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate != null)
                return Context.Set<TEntity>().AnyAsync(predicate);
            else
                return Context.Set<TEntity>().AnyAsync();
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().UpdateRange(entities);
        }

        public Task<TEntity> GetSingleWithInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] include)
        {
            return AllIncluding(predicate, include).FirstOrDefaultAsync();
        }

        public Task<List<TEntity>> AllIncludingAsync(Expression<Func<TEntity, bool>> whereProperties, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return AllIncluding(whereProperties, includeProperties).ToListAsync();
        }

        private IQueryable<TEntity> AllIncluding(Expression<Func<TEntity, bool>> whereProperties, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            if (whereProperties != null)
                query = query.Where(whereProperties);

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }
    }
}