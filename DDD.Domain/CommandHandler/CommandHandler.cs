using System;
using System.Collections.Generic;
using System.Text;
using DDD.Domain.Bus;
using DDD.Domain.Interface;
using DDD.Domain.Notification;
using Microsoft.Extensions.Caching.Memory;

namespace DDD.Domain.CommandHandler
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="bus"></param>
        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus)
        {
            _uow = uow;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command.Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                //将错误信息提交到事件总线，派发出去
                _bus.RaiseEvent(new DomainNotification("", error.ErrorMessage));
            }
        }
        
        //工作单元提交
        //如果有错误，下一步会在这里添加领域通知
        public bool Commit()
        {
            if (_uow.Commit()) return true;

            return false;
        }
    }
}
