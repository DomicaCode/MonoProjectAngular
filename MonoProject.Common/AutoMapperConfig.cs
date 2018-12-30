using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MonoProject.Model;
using MonoProject.Model.Interfaces;
using MonoProject.WebAPI.ViewModels;

namespace MonoProject.Common
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<VehicleMakeEntity, VehicleDto>().ReverseMap();
                cfg.CreateMap<VehicleModelEntity, VehicleDto>().ReverseMap();
            });
        }

    }
}
