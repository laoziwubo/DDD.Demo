using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DDD.Domain.Event.Student;
using MediatR;

namespace DDD.Domain.EventHandler
{
    public class StudentEventHandler : INotificationHandler<StudentRegisteredEvent>
    {
        // 学习被注册成功后的事件处理方法
        public Task Handle(StudentRegisteredEvent message, CancellationToken cancellationToken)
        {
            // 恭喜您，注册成功，欢迎加入我们。

            return Task.CompletedTask;
        }
    }
}
