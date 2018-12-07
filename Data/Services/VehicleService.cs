using Data.Entities;
using Data.Interfaces;
using EntityFrameworkPaginateCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;
using System.Linq;
using AutoMapper;
using Data.Context;
using System.Threading.Tasks;

namespace Data.Services
{
    public class VehicleService : IVehicleService
    {

        private readonly IMakeRepository _makeRepository;

        private readonly IModelRepository _modelRepository;

        private readonly ProjectDbContext _dbContext;



        public VehicleService(IMakeRepository makeRepository, IModelRepository modelRepository, ProjectDbContext context)
        {
            _makeRepository = makeRepository;
            _modelRepository = modelRepository;
            _dbContext = context;
        }

        public async Task<IEnumerable<VehicleDto>> GetMake(int index, int count)
        {
            var data =  await _makeRepository.SelectListMake(index, count, p => p.Id);

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleMakeEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper(); 

            var vehicleDto = mapper.Map<IEnumerable<VehicleMakeEntity>, IEnumerable<VehicleDto>>(data);

            return vehicleDto;
        }
        
        public async Task<IEnumerable<VehicleDto>> GetModel(int index, int count)
        {
            var data = await _modelRepository.SelectListModel(index, count, p => p.Id);

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleModelEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var vehicleDto = mapper.Map<IEnumerable<VehicleModelEntity>, IEnumerable<VehicleDto>>(data);

            return vehicleDto;
        }
        
        public async Task InsertMake(VehicleDto vehicleDto)
        {
            
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleDto, VehicleMakeEntity>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);
            
             await _makeRepository.Insert(entity);
        }

        public async Task InsertModel(VehicleDto vehicleDto)
        {
            
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleDto, VehicleModelEntity>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);
            

            await _modelRepository.Insert(entity);
        }

        public async Task DeleteMake(VehicleDto vehicleDto)
        {
            
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleDto, VehicleMakeEntity>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);
            
            await _makeRepository.Delete(entity);
        }

        public async Task DeleteModel(VehicleDto vehicleDto)
        {
            
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleDto, VehicleModelEntity>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);
            

            await _modelRepository.Delete(entity);
        }

        public async Task UpdateMake(VehicleDto vehicleDto)
        {
            
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleDto, VehicleMakeEntity>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);
            

            await _makeRepository.Update(entity);
        }

        public async Task UpdateModel(VehicleDto vehicleDto)
        {
            
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleDto, VehicleModelEntity>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);
            

            await _modelRepository.Update(entity);
        }

        public async Task DetailsMake(VehicleDto vehicleDto)
        {
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleMakeEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);


            await _makeRepository.Details(entity);
        }

        public async Task DetailsModel(VehicleDto vehicleDto)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleModelEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);


            await _modelRepository.Details(entity);
        }

        public async Task<VehicleDto> GetMakeById(int id)
        {
            var entity = _dbContext.VehicleMake.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleMakeEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var vehicleDto = mapper.Map<VehicleMakeEntity, VehicleDto>(entity);

            return vehicleDto;
        }

        public async Task<VehicleDto> GetModelByMakeId(int id)
        {
            var entity = _dbContext.VehicleModel.AsNoTracking().Where(x => x.MakeId == id).FirstOrDefault();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleModelEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var vehicleDto = mapper.Map<VehicleModelEntity, VehicleDto>(entity);

            return vehicleDto;
        }

        public async Task<VehicleDto> GetModelById(int id)
        {
            var entity = _dbContext.VehicleModel.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleModelEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var vehicleDto = mapper.Map<VehicleModelEntity, VehicleDto>(entity);

            return vehicleDto;
        }
    }
}
