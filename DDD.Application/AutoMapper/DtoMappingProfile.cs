using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DDD.Application.ViewModel;
using DDD.Domain.Model;

namespace DDD.Application.AutoMapper
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Student, StudentViewModel>()
                .ForMember(d => d.County, o => o.MapFrom(s => s.Address.County))
                .ForMember(d => d.Province, o => o.MapFrom(s => s.Address.Province))
                .ForMember(d => d.City, o => o.MapFrom(s => s.Address.City))
                .ForMember(d => d.Street, o => o.MapFrom(s => s.Address.Street));
        }
    }
}
