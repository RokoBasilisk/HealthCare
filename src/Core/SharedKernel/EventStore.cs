using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SharedKernel
{
    public class EventStore : EventBase
    {
        public Guid Id { get; private init; } = Guid.NewGuid();

        public string Data { get; private init; }

        public EventStore(Guid aggregateId, string messageType, string data)
        {
            AggregateId = aggregateId;
            MessageType = messageType;
            Data = data;
        }
    }
}