using ProgramAcad.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProgramAcad.Common.Repository
{
    public interface IEntityRepository<TEntity> where TEntity : Entity
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task DeleteAsync(Expression<Func<TEntity, bool>> where);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);

        IQueryable<TEntity> Query(string sql);
        TEntity Get(Expression<Func<TEntity, bool>> where, bool activeOnly = true);
        TEntity Get(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params Expression<Func<TEntity, object>>[] include);
        TEntity Get(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params string[] include);

        TEntity GetById(Guid id, bool activeOnly = true);
        Task<TEntity> GetByIdAsync(Guid id, bool activeOnly = true);

        IQueryable<TEntity> GetAll(bool activeOnly = true);
        IQueryable<TEntity> GetAll(bool activeOnly = true, params Expression<Func<TEntity, object>>[] include);
        IQueryable<TEntity> GetAll(bool activeOnly = true, params string[] include);
        Task<IQueryable<TEntity>> GetAllAsync(bool activeOnly = true);
        Task<IQueryable<TEntity>> GetAllAsync(bool activeOnly = true, params Expression<Func<TEntity, object>>[] include);
        Task<IQueryable<TEntity>> GetAllAsync(bool activeOnly = true, params string[] include);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where, bool activeOnly = true);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params Expression<Func<TEntity, object>>[] include);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params string[] include);

        IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where, bool activeOnly = true);
        IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params Expression<Func<TEntity, object>>[] include);
        IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params string[] include);
        Task<IQueryable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where, bool activeOnly = true);
        Task<IQueryable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params Expression<Func<TEntity, object>>[] include);
        Task<IQueryable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params string[] include);

        TEntity GetSingle(Expression<Func<TEntity, bool>> where, bool activeOnly = true);
        TEntity GetSingle(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params Expression<Func<TEntity, object>>[] include);
        TEntity GetSingle(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params string[] include);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where, bool activeOnly = true);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params Expression<Func<TEntity, object>>[] include);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params string[] include);

        bool Any(Expression<Func<TEntity, bool>> where, bool activeOnly = true);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where, bool activeOnly = true);

        int Count(Expression<Func<TEntity, bool>> where = null, bool activeOnly = true);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> where = null, bool activeOnly = true);
    }
}
