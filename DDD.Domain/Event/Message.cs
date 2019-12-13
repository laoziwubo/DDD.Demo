using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace DDD.Domain.Event
{
    public abstract class Message : IRequest
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
