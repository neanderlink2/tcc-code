using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProgramAcad.Common.Extensions;
using ProgramAcad.Common.Repository;
using ProgramAcad.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProgramAcad.Infra.Data.Repository
{
    public class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        private readonly DbSet<TModel> _dbSet;

        protected Repository(ProgramAcadContext dbContext)
        {
            DataContext = dbContext;
            _dbSet = DataContext.Set<TModel>();
        }

        public ProgramAcadContext DataContext { get; private set; }

        #region Transaction

        public IDbContextTransaction BeginTransaction()
        {
            return DataContext.Database.CurrentTransaction == null ? DataContext.Database.BeginTransaction(IsolationLevel.ReadUncommitted) : null;
        }

        public IDbContextTransaction CurrentTransaction()
        {
            return DataContext.Database.CurrentTransaction;
        }

        public void CommitTransaction(IDbContextTransaction transaction)
        {
            if (transaction != null)
                transaction.Commit();
        }

        public void UseTransaction(IDbContextTransaction transaction)
        {
            DataContext.Database.UseTransaction((DbTransaction)transaction);
        }

        #endregion Transaction

        #region RawSql

        public virtual IQueryable<TModel> Query(string sql)
        {
            return DataContext.Database.GetDbConnection().Query<TModel>(sql).AsQueryable();
        }
        #endregion

        #region Add
        public virtual async Task AddAsync(TModel entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual Task AddRangeAsync(IEnumerable<TModel> entities)
        {
            return _dbSet.AddRangeAsync(entities);
        }

        #endregion Add

        #region Update

        public virtual Task UpdateAsync(TModel entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task UpdateRangeAsync(IEnumerable<TModel> entities)
        {
            _dbSet.UpdateRange(entities);
            return Task.CompletedTask;
        }

        #endregion Update

        #region Delete

        public virtual Task DeleteAsync(Expression<Func<TModel, bool>> where)
        {
            _dbSet.Where(where).ToList().ForEach(obj => _dbSet.Remove(obj));
            return Task.CompletedTask;
        }

        public virtual Task DeleteAsync(TModel entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        #endregion Delete

        #region Get

        public virtual TModel Get(Expression<Func<TModel, bool>> where)
        {
            return _dbSet.FirstOrDefault(where);
        }

        public virtual async Task<TModel> GetAsync(Expression<Func<TModel, bool>> where)
        {
            return await _dbSet.FirstOrDefaultAsync(where);
        }

        public virtual TModel Get(Expression<Func<TModel, bool>> where, params Expression<Func<TModel, object>>[] include)
        {
            return _dbSet.IncludeMultiple(include).FirstOrDefault(where);
        }

        public virtual async Task<TModel> GetAsync(Expression<Func<TModel, bool>> where, params Expression<Func<TModel, object>>[] include)
        {
            return await _dbSet.IncludeMultiple(include).FirstOrDefaultAsync(where);
        }

        public virtual TModel Get(Expression<Func<TModel, bool>> where, params string[] include)
        {
            return _dbSet.IncludeMultiple(include).FirstOrDefault(where);
        }

        public virtual async Task<TModel> GetAsync(Expression<Func<TModel, bool>> where, params string[] include)
        {
            return await _dbSet.IncludeMultiple(include).FirstOrDefaultAsync(where);
        }

        #endregion Get

        #region GetSingle

        public virtual TModel GetSingle(Expression<Func<TModel, bool>> where)
        {
            return _dbSet.SingleOrDefault(where);
        }

        public virtual async Task<TModel> GetSingleAsync(Expression<Func<TModel, bool>> where)
        {
            return await _dbSet.SingleOrDefaultAsync(where);
        }

        public virtual TModel GetSingle(Expression<Func<TModel, bool>> where, params Expression<Func<TModel, object>>[] include)
        {
            return _dbSet.IncludeMultiple(include).SingleOrDefault(where);
        }

        public virtual async Task<TModel> GetSingleAsync(Expression<Func<TModel, bool>> where, params Expression<Func<TModel, object>>[] include)
        {
            return await _dbSet.IncludeMultiple(include).SingleOrDefaultAsync(where);
        }

        public virtual TModel GetSingle(Expression<Func<TModel, bool>> where, params string[] include)
        {
            return _dbSet.IncludeMultiple(include).SingleOrDefault(where);
        }

        public virtual async Task<TModel> GetSingleAsync(Expression<Func<TModel, bool>> where, params string[] include)
        {
            return await _dbSet.IncludeMultiple(include).SingleOrDefaultAsync(where);
        }

        #endregion GetSingle

        #region GetAll

        public virtual IQueryable<TModel> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public virtual IQueryable<TModel> GetAll(params Expression<Func<TModel, object>>[] include)
        {
            return _dbSet.AsNoTracking().IncludeMultiple(include);
        }

        public virtual IQueryable<TModel> GetAll(params string[] include)
        {
            return _dbSet.AsNoTracking().IncludeMultiple(include);
        }

        public virtual Task<IQueryable<TModel>> GetAllAsync()
        {
            return Task.FromResult(_dbSet.AsNoTracking());
        }

        public virtual Task<IQueryable<TModel>> GetAllAsync(params Expression<Func<TModel, object>>[] include)
        {
            return Task.FromResult(_dbSet.AsNoTracking().IncludeMultiple(include));
        }

        public virtual Task<IQueryable<TModel>> GetAllAsync(params string[] include)
        {
            return Task.FromResult(_dbSet.AsNoTracking().IncludeMultiple(include));
        }

        #endregion GetAll

        #region GetMany

        public virtual IQueryable<TModel> GetMany(Expression<Func<TModel, bool>> where)
        {
            return _dbSet.Where(where);
        }

        public virtual IQueryable<TModel> GetMany(Expression<Func<TModel, bool>> where, params Expression<Func<TModel, object>>[] include)
        {
            return _dbSet.IncludeMultiple(include).Where(where);
        }

        public virtual IQueryable<TModel> GetMany(Expression<Func<TModel, bool>> where, params string[] include)
        {
            return _dbSet.IncludeMultiple(include).Where(where);
        }

        public virtual Task<IQueryable<TModel>> GetManyAsync(Expression<Func<TModel, bool>> where)
        {
            return Task.FromResult(_dbSet.Where(where));
        }

        public virtual Task<IQueryable<TModel>> GetManyAsync(Expression<Func<TModel, bool>> where, params Expression<Func<TModel, object>>[] include)
        {
            return Task.FromResult(_dbSet.IncludeMultiple(include).Where(where));
        }

        public virtual Task<IQueryable<TModel>> GetManyAsync(Expression<Func<TModel, bool>> where, params string[] include)
        {
            return Task.FromResult(_dbSet.IncludeMultiple(include).Where(where));
        }


        #endregion GetMany

        #region Count

        public virtual int Count(Expression<Func<TModel, bool>> where = null)
        {
            return _dbSet.Count(where);
        }

        public virtual async Task<int> CountAsync(Expression<Func<TModel, bool>> where = null)
        {
            return await _dbSet.CountAsync(where);
        }

        #endregion

        #region Any

        public bool Any(Expression<Func<TModel, bool>> where = null)
        {
            return _dbSet.Any(where);
        }

        public async Task<bool> AnyAsync(Expression<Func<TModel, bool>> where = null)
        {
            return await _dbSet.AnyAsync(where);
        }

        #endregion
    }
}
