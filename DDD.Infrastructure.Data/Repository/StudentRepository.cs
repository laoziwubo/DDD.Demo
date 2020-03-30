using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.Domain.Interface;
using DDD.Domain.Model;
using DDD.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(StudyContext context)
            : base(context)
        {

        }
        //对特例接口进行实现
        public Student GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
