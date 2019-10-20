using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProgramAcad.Common.Repository
{
    public interface IRepository<TModel> where TModel : class
    {
        Task AddAsync(TModel entity);
        Task AddRangeAsync(IEnumerable<TModel> entities);
        Task DeleteAsync(Expression<Func<TModel, bool>> where);
        Task DeleteAsync(TModel entity);
        Task UpdateAsync(TModel entity);
        Task UpdateRangeAsync(IEnumerable<TModel> entities);

        IQueryable<TModel> Query(string sql);
        TModel Get(Expression<Func<TModel, bool>> where);
        TModel Get(Expression<Func<TModel, bool>> where, params Expression<Func<TModel, object>>[] include);
        TModel Get(Expression<Func<TModel, bool>> where, params string[] include);

        IQueryable<TModel> GetAll();
        IQueryable<TModel> GetAll(params Expression<Func<TModel, object>>[] include);
        IQueryable<TModel> GetAll(params string[] include);
        Task<IQueryable<TModel>> GetAllAsync();
        Task<IQueryable<TModel>> GetAllAsync(params Expression<Func<TModel, object>>[] include);
        Task<IQueryable<TModel>> GetAllAsync(params string[] include);

        Task<TModel> GetAsync(Expression<Func<TModel, bool>> where);
        Task<TModel> GetAsync(Expression<Func<TModel, bool>> where, params Expression<Func<TModel, object>>[] include);
        Task<TModel> GetAsync(Expression<Func<TModel, bool>> where, params string[] include);

        IQueryable<TModel> GetMany(Expression<Func<TModel, bool>> where);
        IQueryable<TModel> GetMany(Expression<Func<TModel, bool>> where, params Expression<Func<TModel, object>>[] include);
        IQueryable<TModel> GetMany(Expression<Func<TModel, bool>> where, params string[] include);
        Task<IQueryable<TModel>> GetManyAsync(Expression<Func<TModel, bool>> where);
        Task<IQueryable<TModel>> GetManyAsync(Expression<Func<TModel, bool>> where, params Expression<Func<TModel, object>>[] include);
        Task<IQueryable<TModel>> GetManyAsync(Expression<Func<TModel, bool>> where, params string[] include);

        TModel GetSingle(Expression<Func<TModel, bool>> where);
        TModel GetSingle(Expression<Func<TModel, bool>> where, params Expression<Func<TModel, object>>[] include);
        TModel GetSingle(Expression<Func<TModel, bool>> where, params string[] include);
        Task<TModel> GetSingleAsync(Expression<Func<TModel, bool>> where);
        Task<TModel> GetSingleAsync(Expression<Func<TModel, bool>> where, params Expression<Func<TModel, object>>[] include);
        Task<TModel> GetSingleAsync(Expression<Func<TModel, bool>> where, params string[] include);

        bool Any(Expression<Func<TModel, bool>> where);
        Task<bool> AnyAsync(Expression<Func<TModel, bool>> where);

        int Count(Expression<Func<TModel, bool>> where = null);
        Task<int> CountAsync(Expression<Func<TModel, bool>> where = null);
    }
}
