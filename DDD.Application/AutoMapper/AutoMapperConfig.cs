using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace DDD.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoMappingProfile());
                cfg.AddProfile(new ModelMappingProfile());
            });
        }
    }
}
