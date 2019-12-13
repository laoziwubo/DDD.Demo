using AutoMapper;
using DDD.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DDD.Demo.Extension
{
    public static class AutoMapperStartup
    {
        public static void AddAutoMapperStartup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            //添加服务
            services.AddAutoMapper(typeof(AutoMapperConfig));
            //启动配置
            AutoMapperConfig.RegisterMappings();
        }
    }
}
