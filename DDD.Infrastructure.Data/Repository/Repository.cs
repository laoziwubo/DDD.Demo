using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.Domain.Interface;
using DDD.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly StudyContext Db;
        protected readonly DbSet<T> DbSet;
        public Repository(StudyContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public virtual void Add(T obj)
        {
            DbSet.Add(obj);
        }

        public virtual T GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(T obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
