using MonoProject.Model;
using MonoProject.Service.Common;
using MonoProject.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;
using System.Linq;
using AutoMapper;
using MonoProject.DAL;
using System.Threading.Tasks;

namespace MonoProject.Service
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

        public async Task<IEnumerable<VehicleDto>> AsyncGetMake(int index, int count)
        {
            var data =  await _makeRepository.AsyncGetMake(index, count, p => p.Id);

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleMakeEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper(); 

            var vehicleDto = mapper.Map<IEnumerable<VehicleMakeEntity>, IEnumerable<VehicleDto>>(data);

            return vehicleDto;
        }
        
        public async Task<IEnumerable<VehicleDto>> GetModel(int index, int count)
        {
            var data = await _modelRepository.AsyncGetModel(index, count, p => p.Id);

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleModelEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var vehicleDto = mapper.Map<IEnumerable<VehicleModelEntity>, IEnumerable<VehicleDto>>(data);

            return vehicleDto;
        }
        
        public async Task AsyncInsertMake(VehicleDto vehicleDto)
        {
            
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleDto, VehicleMakeEntity>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);
            
             await _makeRepository.AsyncInsert(entity);
        }

        public async Task AsyncInsertModel(VehicleDto vehicleDto)
        {
            
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleDto, VehicleModelEntity>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);
            

            await _modelRepository.AsyncInsert(entity);
        }

        public async Task AsyncDeleteMake(VehicleDto vehicleDto)
        {
            
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleDto, VehicleMakeEntity>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);
            
            await _makeRepository.AsyncDelete(entity);
        }

        public async Task AsyncDeleteModel(VehicleDto vehicleDto)
        {
            
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleDto, VehicleModelEntity>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);
            

            await _modelRepository.AsyncDelete(entity);
        }

        public async Task AsyncUpdateMake(VehicleDto vehicleDto)
        {
            
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleDto, VehicleMakeEntity>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);
            

            await _makeRepository.AsyncUpdate(entity);
        }

        public async Task AsyncUpdateModel(VehicleDto vehicleDto)
        {
            
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleDto, VehicleModelEntity>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);
            

            await _modelRepository.AsyncUpdate(entity);
        }

        public async Task AsyncDetailsMake(VehicleDto vehicleDto)
        {
            // Ovaj automapper config treba abstractat
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleMakeEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);


            await _makeRepository.AsyncDetails(entity);
        }

        public async Task AsyncDetailsModel(VehicleDto vehicleDto)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleModelEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var entity = mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);


            await _modelRepository.AsyncDetails(entity);
        }

        public async Task<VehicleDto> AsyncGetMakeById(int id)
        {
            var entity = _dbContext.VehicleMake.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleMakeEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var vehicleDto = mapper.Map<VehicleMakeEntity, VehicleDto>(entity);

            return vehicleDto;
        }

        public async Task<VehicleDto> AsyncGetModelByMakeId(int id)
        {
            var entity = _dbContext.VehicleModel.AsNoTracking().Where(x => x.MakeId == id).FirstOrDefault();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleModelEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var vehicleDto = mapper.Map<VehicleModelEntity, VehicleDto>(entity);

            return vehicleDto;
        }

        public async Task<VehicleDto> AsyncGetModelById(int id)
        {
            var entity = _dbContext.VehicleModel.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleModelEntity, VehicleDto>(); });
            IMapper mapper = config.CreateMapper();

            var vehicleDto = mapper.Map<VehicleModelEntity, VehicleDto>(entity);

            return vehicleDto;
        }
    }
}
