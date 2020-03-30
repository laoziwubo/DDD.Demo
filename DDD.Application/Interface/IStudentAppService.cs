using System;
using System.Collections.Generic;
using System.Text;
using DDD.Application.EventSourcedNormalizer;
using DDD.Application.ViewModel;

namespace DDD.Application.Interface
{
    public interface IStudentAppService : IDisposable
    {
        void Register(StudentViewModel studentViewModel);
        IEnumerable<StudentViewModel> GetAll();
        StudentViewModel GetById(Guid id);
        void Update(StudentViewModel studentViewModel);
        void Remove(Guid id);
        IList<StudentHistoryData> GetAllHistory(Guid id);
    }
}
