using System;
using System.Collections.Generic;
using System.Text;
using DDD.Domain.Model;

namespace DDD.Domain.Interface
{
    public interface IStudentRepository : IRepository<Student>
    {
        //一些Student独有的接口
        Student GetByEmail(string email);
    }
}
