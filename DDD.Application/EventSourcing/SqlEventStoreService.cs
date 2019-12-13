using System;
using System.Collections.Generic;
using System.Text;
using DDD.Domain.Event;
using DDD.Infrastructure.Data.Repository.EventSourcing;
using Newtonsoft.Json;

namespace DDD.Application.EventSourcing
{
    public class SqlEventStoreService : IEventStoreService
    {
        // 注入我们的仓储接口
        private readonly IEventStoreRepository _eventStoreRepository;

        public SqlEventStoreService(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        /// <summary>
        /// 保存事件模型统一方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theEvent"></param>
        public void Save<T>(T theEvent) where T : Event
        {
            // 对事件模型序列化
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                ""
                );

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
