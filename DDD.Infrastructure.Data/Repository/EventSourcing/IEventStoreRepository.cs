using System;
using System.Collections.Generic;
using System.Text;
using DDD.Domain.Event;

namespace DDD.Infrastructure.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
