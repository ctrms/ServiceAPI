using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Boyner.API.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetSingle(object id);
        Task<TEntity> GetSingleAsync(object id);
        void MarkForInsertion(TEntity entity);
        Task MarkForInsertionAsync(TEntity entity);
        void MarkForDeletion(object id);
        void MarkForDeletion(TEntity entity);
        IIncludableQueryable<TEntity, TProperty> Include<TProperty>(
            Expression<Func<TEntity, TProperty>> navigationPropertyPath);
    }
}
