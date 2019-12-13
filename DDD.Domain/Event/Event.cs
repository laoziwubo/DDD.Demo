using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace DDD.Domain.Event
{
    public abstract class Event : Message, INotification
    {
        // 时间戳
        public DateTime Timestamp { get; private set; }

        // 每一个事件都是有状态的
        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
