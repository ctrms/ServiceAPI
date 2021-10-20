using Boyner.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Boyner.API.EFUnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbDataContext;

        public EfUnitOfWork(DbContext dbDataContext)
        {
            _dbDataContext = dbDataContext;
        }

        public void Dispose()
        {
            _dbDataContext.Dispose();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var numberRecord = 0;
            using (var transection = _dbDataContext.Database.BeginTransaction())
            {
                var changesets = _dbDataContext.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
                if (changesets.Any())
                {
                    try
                    {
                        numberRecord = await _dbDataContext.SaveChangesAsync(cancellationToken);
                        transection.Commit();
                    }
                    catch (Exception)
                    {
                        transection.Rollback();
                        numberRecord = 0;
                    }
                }
            }
            return numberRecord;
        }
    }
}
