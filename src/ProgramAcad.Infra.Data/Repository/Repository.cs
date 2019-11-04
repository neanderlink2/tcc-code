﻿using Dapper;
using Microsoft.EntityFrameworkCore;
using ProgramAcad.Domain.Contracts;
using ProgramAcad.Infra.Data.Context;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProgramAcad.Infra.Data.Repository
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        private readonly DbSet<TModel> _dbSet;

        protected Repository(ProgramAcadContext dbContext)
        {
            DataContext = dbContext;
            _dbSet = DataContext.Set<TModel>();
        }

        public ProgramAcadContext DataContext { get; private set; }

        public Task AddAsync(TModel entity)
        {
            return Task.Run(() => _dbSet.Add(entity));
        }

        public bool Any(Expression<Func<TModel, bool>> condicao)
        {
            return _dbSet.Any(condicao);
        }

        public Task<bool> AnyAsync(Expression<Func<TModel, bool>> condicao)
        {
            return _dbSet.AnyAsync(condicao);
        }

        public int Count(Expression<Func<TModel, bool>> condicao = null)
        {
            return _dbSet.Count(condicao);
        }

        public Task<int> CountAsync(Expression<Func<TModel, bool>> condicao = null)
        {
            return _dbSet.CountAsync(condicao);
        }

        public Task DeleteAsync(TModel entity)
        {
            return Task.Run(() => _dbSet.Remove(entity));
        }

        public IQueryable<TRetorno> FromSql<TRetorno>(string sql)
        {
            return DataContext.Database.GetDbConnection().Query<TRetorno>(sql).AsQueryable();
        }

        public IQueryable<TModel> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public Task<IQueryable<TModel>> GetAllAsync()
        {
            return Task.Run(() => _dbSet.AsQueryable());
        }

        public IQueryable<TModel> GetMany(Expression<Func<TModel, bool>> condicao)
        {
            return _dbSet.Where(condicao);
        }

        public Task<IQueryable<TModel>> GetManyAsync(Expression<Func<TModel, bool>> condicao)
        {
            return Task.Run(() => _dbSet.Where(condicao));
        }

        public TModel GetSingle(Expression<Func<TModel, bool>> where)
        {
            return _dbSet.FirstOrDefault(where);
        }

        public Task<TModel> GetSingleAsync(Expression<Func<TModel, bool>> condicao)
        {
            return _dbSet.FirstOrDefaultAsync(condicao);
        }

        public Task UpdateAsync(TModel entity)
        {
            return Task.Run(() => _dbSet.Update(entity));
        }
    }
}
