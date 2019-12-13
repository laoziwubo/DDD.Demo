using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DDD.Domain.Event;
using DDD.Infrastructure.Data.DB;
using DDD.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DDD.Infrastructure.Data.Context
{
    public class EventStoreSqlContext : DbContext
    {
        // 事件存储模型
        public DbSet<StoredEvent> StoredEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 获取链接字符串
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // 使用默认的sql数据库连接
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
