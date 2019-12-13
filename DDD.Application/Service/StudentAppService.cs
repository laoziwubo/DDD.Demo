using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DDD.Application.EventSourcedNormalizer;
using DDD.Application.ViewModel;
using DDD.Domain.Bus;
using DDD.Domain.Command.Student;
using DDD.Domain.Interface;
using DDD.Domain.Model;
using DDD.Infrastructure.Data.Repository.EventSourcing;

namespace DDD.Application.Service
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        //private readonly IEventStoreRepository _eventStoreRepository;

        public StudentAppService(
            IStudentRepository studentRepository,
            IMapper mapper,
            IMediatorHandler bus
            //IEventStoreRepository eventStoreRepository
        )
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _bus = bus;
            //_eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<StudentViewModel> GetAll()
        {

            //第一种写法 Map
            return _mapper.Map<IEnumerable<StudentViewModel>>(_studentRepository.GetAll());

            //第二种写法 ProjectTo
            //return (_StudentRepository.GetAll()).ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider);
        }

        public StudentViewModel GetById(Guid id)
        {
            return _mapper.Map<StudentViewModel>(_studentRepository.GetById(id));
        }

        public void Register(StudentViewModel studentViewModel)
        {
            //这里引入领域设计中的写命令 还没有实现
            //请注意这里如果是平时的写法，必须要引入Student领域模型，会造成污染
            //_studentRepository.Add(_mapper.Map<Student>(studentViewModel));
            //_studentRepository.SaveChanges();

            var registerCommand = _mapper.Map<RegisterStudentCommand>(studentViewModel);
            _bus.SendCommand(registerCommand);
        }

        public void Update(StudentViewModel studentViewModel)
        {
            var updateCommand = _mapper.Map<UpdateStudentCommand>(studentViewModel);
            //_bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveStudentCommand(id);
            //_bus.SendCommand(removeCommand);

        }

        /// <summary>
        /// 获取某一个聚合id下的所有事件，也就是得到了历史记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<StudentHistoryData> GetAllHistory(Guid id)
        {
            return null;
            //return StudentHistory.ToJavaScriptStudentHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
