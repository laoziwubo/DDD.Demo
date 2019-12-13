using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Domain.Interface
{
    public interface IRepository<T> : IDisposable where T : class
    {
        void Add(T obj);
        
        T GetById(Guid id);
        
        IQueryable<T> GetAll();
        
        void Update(T obj);
        
        void Remove(Guid id);
        
        int SaveChanges();
    }
}
