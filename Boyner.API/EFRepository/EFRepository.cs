using Boyner.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Boyner.API.EFRepository
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;

        public EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<TEntity> Entities => _dbContext.Set<TEntity>();
        public TEntity GetSingle(object id)
        {
            return Entities.Find(id);
        }


        public async Task<TEntity> GetSingleAsync(object id)
        {
            return await Entities.FindAsync(id);
        }

        public Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<TEntity, TProperty> Include<TProperty>(System.Linq.Expressions.Expression<Func<TEntity, TProperty>> navigationPropertyPath)
        {
            return Entities.Include(navigationPropertyPath);
        }

        public void MarkForDeletion(object id)
        {
            Entities.Remove(GetSingle(id));
        }

        public void MarkForDeletion(TEntity entity)
        {
            try
            {
                Entities.Remove(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void MarkForInsertion(TEntity entity)
        {
            try
            {
                Entities.Add(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task MarkForInsertionAsync(TEntity entity)
        {
            try
            {
                await Entities.AddAsync(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
