﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.Domain.Event;
using DDD.Infrastructure.Context;

namespace DDD.Infrastructure.Repository.EventSourcing
{
    public class EventStoreSqlRepository : IEventStoreRepository
    {
        // 注入事件存储数据库上下文
        private readonly EventStoreSqlContext _context;

        public EventStoreSqlRepository(EventStoreSqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 根据聚合id 获取全部的事件
        /// 这个聚合是指领域模型的聚合根模型
        /// </summary>
        /// <param name="aggregateId"> 聚合根id 比如：订单模型id</param>
        /// <returns></returns>
        public IList<StoredEvent> All(Guid aggregateId)
        {
            return (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToList();
        }

        /// <summary>
        /// 将命令事件持久化
        /// </summary>
        /// <param name="theEvent"></param>
        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }

        /// <summary>
        /// 手动回收
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
