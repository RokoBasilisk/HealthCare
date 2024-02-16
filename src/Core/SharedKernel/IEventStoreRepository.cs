using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SharedKernel
{
    public interface IEventStoreRepository : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventStores"></param>
        /// <returns></returns>
        Task StoreAsync(IEnumerable<EventStore> eventStores);
    }
}
