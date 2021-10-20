﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Boyner.API.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
