using System;
using System.Collections.Generic;
using System.Text;
using DDD.Domain.Interface;
using DDD.Infrastructure.Context;

namespace DDD.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        //数据库上下文
        private readonly StudyContext _context;

        //构造函数注入
        public UnitOfWork(StudyContext context)
        {
            _context = context;
        }

        //上下文提交
        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        //手动回收
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
