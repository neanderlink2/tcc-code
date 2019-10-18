using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProgramAcad.Common.Extensions;
using ProgramAcad.Common.Models;
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
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DbSet<TEntity> _dbSet;

        protected Repository(ProgramAcadContext dbContext)
        {
            DataContext = dbContext;
            _dbSet = DataContext.Set<TEntity>();
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

        public virtual IQueryable<TEntity> Query(string sql)
        {
            return DataContext.Database.GetDbConnection().Query<TEntity>(sql).AsQueryable();
        }
        #endregion

        #region Add
        public virtual async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            return _dbSet.AddRangeAsync(entities);
        }

        #endregion Add

        #region Update

        public virtual Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            return Task.CompletedTask;
        }

        #endregion Update

        #region Delete

        public virtual Task DeleteAsync(Expression<Func<TEntity, bool>> where)
        {
            _dbSet.Where(where).ToList().ForEach(obj => _dbSet.Remove(obj));
            return Task.CompletedTask;
        }

        public virtual Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        #endregion Delete

        #region Get

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where, bool activeOnly = true)
        {
            return _dbSet.Where(x => activeOnly ? x.Status : true).FirstOrDefault(where);
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where, bool activeOnly = true)
        {
            return await _dbSet.Where(x => activeOnly ? x.Status : true).FirstOrDefaultAsync(where);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params Expression<Func<TEntity, object>>[] include)
        {
            return _dbSet.Where(x => activeOnly ? x.Status : true).IncludeMultiple(include).FirstOrDefault(where);
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params Expression<Func<TEntity, object>>[] include)
        {
            return await _dbSet.Where(x => activeOnly ? x.Status : true).IncludeMultiple(include).FirstOrDefaultAsync(where);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params string[] include)
        {
            return _dbSet.Where(x => activeOnly ? x.Status : true).IncludeMultiple(include).FirstOrDefault(where);
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params string[] include)
        {
            return await _dbSet.Where(x => activeOnly ? x.Status : true).IncludeMultiple(include).FirstOrDefaultAsync(where);
        }

        #endregion Get

        #region GetSingle

        public virtual TEntity GetSingle(Expression<Func<TEntity, bool>> where, bool activeOnly = true)
        {
            return _dbSet.Where(x => activeOnly ? x.Status : true).SingleOrDefault(where);
        }

        public virtual async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where, bool activeOnly = true)
        {
            return await _dbSet.Where(x => activeOnly ? x.Status : true).SingleOrDefaultAsync(where);
        }

        public virtual TEntity GetSingle(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params Expression<Func<TEntity, object>>[] include)
        {
            return _dbSet.Where(x => activeOnly ? x.Status : true).IncludeMultiple(include).SingleOrDefault(where);
        }

        public virtual async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params Expression<Func<TEntity, object>>[] include)
        {
            return await _dbSet.Where(x => activeOnly ? x.Status : true).IncludeMultiple(include).SingleOrDefaultAsync(where);
        }

        public virtual TEntity GetSingle(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params string[] include)
        {
            return _dbSet.Where(x => activeOnly ? x.Status : true).IncludeMultiple(include).SingleOrDefault(where);
        }

        public virtual async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params string[] include)
        {
            return await _dbSet.Where(x => activeOnly ? x.Status : true).IncludeMultiple(include).SingleOrDefaultAsync(where);
        }

        #endregion GetSingle

        #region GetAll

        public virtual IQueryable<TEntity> GetAll(bool activeOnly = true)
        {
            return _dbSet.Where(x => activeOnly ? x.Status : true).AsNoTracking();
        }

        public virtual IQueryable<TEntity> GetAll(bool activeOnly = true, params Expression<Func<TEntity, object>>[] include)
        {
            return _dbSet.Where(x => activeOnly ? x.Status : true).AsNoTracking().IncludeMultiple(include);
        }

        public virtual IQueryable<TEntity> GetAll(bool activeOnly = true, params string[] include)
        {
            return _dbSet.Where(x => activeOnly ? x.Status : true).AsNoTracking().IncludeMultiple(include);
        }

        public virtual Task<IQueryable<TEntity>> GetAllAsync(bool activeOnly = true)
        {
            return Task.FromResult(_dbSet.Where(x => activeOnly ? x.Status : true).AsNoTracking());
        }

        public virtual Task<IQueryable<TEntity>> GetAllAsync(bool activeOnly = true, params Expression<Func<TEntity, object>>[] include)
        {
            return Task.FromResult(_dbSet.Where(x => activeOnly ? x.Status : true).AsNoTracking().IncludeMultiple(include));
        }

        public virtual Task<IQueryable<TEntity>> GetAllAsync(bool activeOnly = true, params string[] include)
        {
            return Task.FromResult(_dbSet.Where(x => activeOnly ? x.Status : true).AsNoTracking().IncludeMultiple(include));
        }

        #endregion GetAll

        #region GetMany

        public virtual IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where, bool activeOnly = true)
        {
            return _dbSet.Where(x => activeOnly ? x.Status : true).Where(where);
        }

        public virtual IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params Expression<Func<TEntity, object>>[] include)
        {
            return _dbSet.Where(x => activeOnly ? x.Status : true).IncludeMultiple(include).Where(where);
        }

        public virtual IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params string[] include)
        {
            return _dbSet.Where(x => activeOnly ? x.Status : true).IncludeMultiple(include).Where(where);
        }

        public virtual Task<IQueryable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where, bool activeOnly = true)
        {
            return Task.FromResult(_dbSet.Where(x => activeOnly ? x.Status : true).Where(where));
        }

        public virtual Task<IQueryable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params Expression<Func<TEntity, object>>[] include)
        {
            return Task.FromResult(_dbSet.Where(x => activeOnly ? x.Status : true).IncludeMultiple(include).Where(where));
        }

        public virtual Task<IQueryable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where, bool activeOnly = true, params string[] include)
        {
            return Task.FromResult(_dbSet.Where(x => activeOnly ? x.Status : true).IncludeMultiple(include).Where(where));
        }


        #endregion GetMany

        #region Count

        public virtual int Count(Expression<Func<TEntity, bool>> where = null, bool activeOnly = true)
        {
            return _dbSet.Where(x => activeOnly ? x.Status : true).Count(where);
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> where = null, bool activeOnly = true)
        {
            return await _dbSet.Where(x => activeOnly ? x.Status : true).CountAsync(where);
        }

        #endregion

        #region Any

        public bool Any(Expression<Func<TEntity, bool>> where = null, bool activeOnly = true)
        {
            return _dbSet.Where(x => activeOnly ? x.Status : true).Any(where);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where = null, bool activeOnly = true)
        {
            return await _dbSet.Where(x => activeOnly ? x.Status : true).AnyAsync(where);
        }

        #endregion
    }
}
