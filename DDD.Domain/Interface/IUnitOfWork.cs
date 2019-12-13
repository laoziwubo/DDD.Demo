using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        //是否提交成功
        bool Commit();
    }
}
