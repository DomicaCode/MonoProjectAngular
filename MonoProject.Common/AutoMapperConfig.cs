using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MonoProject.Model;

namespace MonoProject.Common
{
    public class AutoMapperConfig
    {
        public VehicleMakeEntity MapViewModelToEntityMake(VehicleDto viewModel)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleDto, VehicleMakeEntity>(); });
            IMapper mapper = config.CreateMapper();
            var entity = mapper.Map<VehicleDto, VehicleMakeEntity>(viewModel);
            return entity;
        }

        public VehicleDto MapEntityToViewModelMake(VehicleMakeEntity entity)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleMakeEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();
            var viewModel = mapper.Map<VehicleMakeEntity, VehicleDto>(entity);


            return viewModel;
        }

    }
}
