﻿using Auth.Infrastructure.Persistence;
using Auth.Infrastructure.Repositories.Common;
using Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositories
{
    public class EventStoreRepository(EventStoreDbContext _context) : IEventStoreRepository
    {
        public async Task StoreAsync(IEnumerable<EventStore> eventStores)
        {
            await _context.AddRangeAsync(eventStores);
            await _context.SaveChangesAsync();
        }

        private bool disposedValue;


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~EventStoreRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
