using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.Core.Infrastructre.RepositoryAbstraction
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase, new()
    {
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> sortBy = null, int? skip = null, int? take = null);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetSingleWithInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] include);
        Task<List<TEntity>> AllIncludingAsync(Expression<Func<TEntity, bool>> whereProperties, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<bool> IfAnyAsync(Expression<Func<TEntity, bool>> predicate);
        void DeleteWhere(Expression<Func<TEntity, bool>> predicate);
        void Delete(TEntity entity);
    }
}
