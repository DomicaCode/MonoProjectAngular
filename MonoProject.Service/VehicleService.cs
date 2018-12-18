using MonoProject.Model;
using MonoProject.Service.Common;
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
using MonoProject.Common;
using Ninject;

namespace MonoProject.Service
{
    public class VehicleService : IVehicleService
    {


        private readonly ProjectDbContext _dbContext;

        private IUnitOfWork _unitOfWork;


        public VehicleService(ProjectDbContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbContext = context;
        }


        public async Task<IEnumerable<VehicleDto>> GetMakeAsync(int index, int count)
        {
            var data =  await _unitOfWork.MakeRepository.GetAsync(index, count, p => p.Id);

            var vehicleDto = AutoMapper.Mapper.Map<IEnumerable<VehicleMakeEntity>, IEnumerable<VehicleDto>>(data);

            return vehicleDto;
        }
        
        public async Task<IEnumerable<VehicleDto>> GetModelAsync(int index, int count)
        {
            var data = await _unitOfWork.ModelRepository.GetAsync(index, count, p => p.Id);

            var vehicleDto = AutoMapper.Mapper.Map<IEnumerable<VehicleModelEntity>, IEnumerable<VehicleDto>>(data);

            return vehicleDto;
        }
        
        public async Task InsertMakeAsync(VehicleDto vehicleDto)
        {
            var entity = AutoMapper.Mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);
            
             await _unitOfWork.MakeRepository.InsertAsync(entity);
        }

        public async Task InsertModelAsync(VehicleDto vehicleDto)
        {

            var entity = AutoMapper.Mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);
            

            await _unitOfWork.ModelRepository.InsertAsync(entity);
        }

        public async Task DeleteMakeAsync(VehicleDto vehicleDto)
        {

            var entity = AutoMapper.Mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);
            
            await _unitOfWork.MakeRepository.DeleteAsync(entity);
        }

        public async Task DeleteModelAsync(VehicleDto vehicleDto)
        {
            var entity = AutoMapper.Mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);
            

            await _unitOfWork.ModelRepository.DeleteAsync(entity);
        }

        public async Task UpdateMakeAsync(VehicleDto vehicleDto)
        {
            var entity = AutoMapper.Mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);
            

            await _unitOfWork.MakeRepository.EditAsync(entity);
        }

        public async Task UpdateModelAsync(VehicleDto vehicleDto)
        {
            var entity = AutoMapper.Mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);
            

            await _unitOfWork.ModelRepository.EditAsync(entity);
        }

        public async Task DetailsMakeAsync(VehicleDto vehicleDto)
        {

            var entity = AutoMapper.Mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);


            await _unitOfWork.MakeRepository.DetailsAsync(entity);
        }

        public async Task DetailsModelAsync(VehicleDto vehicleDto)
        {
            var entity = AutoMapper.Mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);


            await _unitOfWork.ModelRepository.DetailsAsync(entity);
        }

        public async Task<VehicleDto> GetMakeByIdAsync(int id)
        {
            var entity = _dbContext.VehicleMake.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();

            var vehicleDto = AutoMapper.Mapper.Map<VehicleMakeEntity, VehicleDto>(entity);

            return vehicleDto;
        }

        public async Task<VehicleDto> GetModelByMakeIdAsync(int id)
        {
            var entity = _dbContext.VehicleModel.AsNoTracking().Where(x => x.MakeId == id).FirstOrDefault();

            var vehicleDto = AutoMapper.Mapper.Map<VehicleModelEntity, VehicleDto>(entity);

            return vehicleDto;
        }

        public async Task<VehicleDto> GetModelByIdAsync(int id)
        {
            var entity = _dbContext.VehicleModel.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();

            var vehicleDto = AutoMapper.Mapper.Map<VehicleModelEntity, VehicleDto>(entity);

            return vehicleDto;
        }
    }
}
