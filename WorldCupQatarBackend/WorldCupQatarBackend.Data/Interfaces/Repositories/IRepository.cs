﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using WorldCupQatarBackend.Data.Interfaces.Models;

namespace WorldCupQatarBackend.Data.Interfaces.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        public Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null, List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> includes = null, Expression<Func<T, object>> orderAsc = null, Expression<Func<T, object>> orderDesc1 = null, Expression<Func<T, object>> orderDesc2 = null);
        public Task<T> GetFirstAsync(Expression<Func<T, bool>> filter = null, List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> includes = null, Expression<Func<T, object>> orderAsc = null, Expression<Func<T, object>> orderDesc = null);
        public Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null, List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> includes = null, Expression<Func<T, object>> orderAsc = null, Expression<Func<T, object>> orderDesc = null);
        public void Add(T entity);
        public void Update(T entity);

        public Task<List<TProjection>> GetProjectedListAsync<TProjection>(Expression<Func<T, TProjection>> selector = null, Expression<Func<T, bool>> filter = null) where TProjection: class;
    }
}
