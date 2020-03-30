using DDD.Application.EventSourcing;
using DDD.Application.Service;
using DDD.Application.Interface;
using DDD.Domain.Bus;
using DDD.Domain.Command.Student;
using DDD.Domain.CommandHandler;
using DDD.Domain.Event;
using DDD.Domain.Event.Student;
using DDD.Domain.EventHandler;
using DDD.Domain.Interface;
using DDD.Domain.Notification;
using DDD.Infrastructure.Bus;
using DDD.Infrastructure.Context;
using DDD.Infrastructure.Repository;
using DDD.Infrastructure.Repository.EventSourcing;
using DDD.Infrastructure.UoW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Demo.Extension
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            // ASP.NET Authorization Polices
            //services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();


            // 注入 应用层Application
            services.AddScoped<IStudentAppService, StudentAppService>();
            //services.AddScoped<IOrderAppService, OrderAppService>();


            // 命令总线Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            
            
            // 领域通知
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();


            // 领域事件
            services.AddScoped<INotificationHandler<StudentRegisteredEvent>, StudentEventHandler>();
            //services.AddScoped<INotificationHandler<StudentUpdatedEvent>, StudentEventHandler>();
            //services.AddScoped<INotificationHandler<StudentRemovedEvent>, StudentEventHandler>();


            // 领域层 - 领域命令
            // 将命令模型和命令处理程序匹配
            services.AddScoped<IRequestHandler<RegisterStudentCommand, Unit>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateStudentCommand, Unit>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveStudentCommand, Unit>, StudentCommandHandler>();
            //services.AddScoped<IRequestHandler<RegisterOrderCommand, Unit>, OrderCommandHandler>();


            // 领域层 - Memory
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });

        
            // 注入 基础设施层 - 数据层
            services.AddScoped<IStudentRepository, StudentRepository>();
            //services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<StudyContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            // 注入 基础设施层 - 事件溯源
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStoreService, SqlEventStoreService>();
            services.AddScoped<EventStoreSqlContext>();


            // 注入 基础设施层 - Identity Services
            //services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            //services.AddTransient<ISmsSender, AuthSMSMessageSender>();


            // 注入 基础设施层 - Identity
            //services.AddScoped<IUser, AspNetUser>();
        }
    }
}
