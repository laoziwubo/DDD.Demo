using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DDD.Domain.Bus;
using DDD.Domain.Command.Student;
using DDD.Domain.Event.Student;
using DDD.Domain.Interface;
using DDD.Domain.Model;
using DDD.Domain.Notification;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace DDD.Domain.CommandHandler
{
    public class StudentCommandHandler : CommandHandler,
        IRequestHandler<RegisterStudentCommand, Unit>,
        IRequestHandler<UpdateStudentCommand, Unit>,
        IRequestHandler<RemoveStudentCommand, Unit>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMediatorHandler _bus;
        public StudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork uow, IMediatorHandler bus) : base(uow, bus)
        {
            _studentRepository = studentRepository;
            _bus = bus;
        }

        public Task<Unit> Handle(RegisterStudentCommand message, CancellationToken cancellationToken)
        {
            // 命令验证
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(new Unit());
            }

            // 实例化领域模型，这里才真正的用到了领域模型
            // 注意这里是通过构造函数方法实现
            var address = new Address(message.Province, message.City, message.County, message.Street);
            var customer = new Student(Guid.NewGuid(), message.Name, message.Email, message.Phone, message.BirthDate, address);

            // 判断邮箱是否存在
            // 这些业务逻辑，当然要在领域层中（领域命令处理程序中）进行处理
            if (_studentRepository.GetByEmail(customer.Email) != null)
            {
                //这里对错误信息进行发布，目前采用缓存形式
                //var errorInfo = new List<string>() { "The customer e-mail has already been taken." };
                //_cache.Set("ErrorData", errorInfo);
                //return Task.FromResult(new Unit());

                //引发错误事件
                _bus.RaiseEvent(new DomainNotification("", "该邮箱已经被使用！"));
                return Task.FromResult(new Unit());
            }

            // 持久化
            _studentRepository.Add(customer);

            // 统一提交
            if (Commit())
            {
                // 提交成功后，这里需要发布领域事件
                // 比如欢迎用户注册邮件呀，短信呀等

                _bus.RaiseEvent(new StudentRegisteredEvent(message.Id, message.Name, message.Email, message.BirthDate, message.Phone));
            }

            return Task.FromResult(new Unit());

        }

        public Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _studentRepository.Dispose();
        }
    }
}
