using Boyner.API.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Boyner.API.Queries
{
    public class BaseQuery<TEntity> where TEntity : class
    {
        private readonly DbContext _context;

        public BaseQuery(DbContext dbContext)
        {
            _context = dbContext;
        }

        protected DbSet<TEntity> Query => _context.Set<TEntity>();

        public virtual async Task<TEntity> FindAsync(object id)
        {
            return await Query.FindAsync(id);
        }
        public static IQueryable<TEntity> Include<TEntity>(IEnumerable<string> navigationPropertyPaths, IQueryable<TEntity> source)
            where TEntity : class
        {
            return navigationPropertyPaths.Aggregate(source, (query, path) => query.Include(path));
        }
        protected virtual IQueryable<TEntity> IncludeAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            var query = _context.Set<TEntity>()
                .Include(_context.GetIncludePaths(typeof(TEntity)));
            if (predicate != null)
                query = query.Where(predicate);
            return query;
        }

    }
}

