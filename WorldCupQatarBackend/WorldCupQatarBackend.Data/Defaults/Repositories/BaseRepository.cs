using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorldCupQatarBackend.Data.Interfaces.Models;
using WorldCupQatarBackend.Data.Interfaces.Repositories;

namespace WorldCupQatarBackend.Data.Defaults.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly WorldCupDbContext _context;

        public BaseRepository(WorldCupDbContext context)
        {
            _context = context;
        }

        private IQueryable<T> QueryBuilder(IQueryable<T> baseQuery, Expression<Func<T, bool>> filter = null, List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> includes = null, Expression<Func<T, object>> orderByDesc = null)
        {
            var query = baseQuery;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => include(current));
            }

            if (orderByDesc != null)
            {
                query = query.OrderByDescending(orderByDesc);
            }

            return query;
        }
        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null, List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> includes = null, Expression<Func<T, object>> orderByDesc = null)
        {
            return await QueryBuilder(_context.Set<T>().AsQueryable(), filter, includes, orderByDesc)
                            .ToListAsync();
        }

        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> filter = null, List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> includes = null, Expression<Func<T, object>> orderByDesc = null)
        {
            return await QueryBuilder(_context.Set<T>().AsQueryable(), filter, includes, orderByDesc)
                            .FirstOrDefaultAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null, List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> includes = null, Expression<Func<T, object>> orderByDesc = null)
        {
            return await QueryBuilder(_context.Set<T>().AsQueryable(), filter, includes, orderByDesc)
                            .AnyAsync();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }


    }
}
