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


        public async Task<IEnumerable<VehicleDto>> AsyncGetMake(int index, int count)
        {
            var data =  await _unitOfWork.MakeRepository.AsyncGet(index, count, p => p.Id);

            var vehicleDto = AutoMapper.Mapper.Map<IEnumerable<VehicleMakeEntity>, IEnumerable<VehicleDto>>(data);

            return vehicleDto;
        }
        
        public async Task<IEnumerable<VehicleDto>> AsyncGetModel(int index, int count)
        {
            var data = await _unitOfWork.ModelRepository.AsyncGet(index, count, p => p.Id);

            var vehicleDto = AutoMapper.Mapper.Map<IEnumerable<VehicleModelEntity>, IEnumerable<VehicleDto>>(data);

            return vehicleDto;
        }
        
        public async Task AsyncInsertMake(VehicleDto vehicleDto)
        {
            var entity = AutoMapper.Mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);
            
             await _unitOfWork.MakeRepository.AsyncInsert(entity);
        }

        public async Task AsyncInsertModel(VehicleDto vehicleDto)
        {

            var entity = AutoMapper.Mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);
            

            await _unitOfWork.ModelRepository.AsyncInsert(entity);
        }

        public async Task AsyncDeleteMake(VehicleDto vehicleDto)
        {

            var entity = AutoMapper.Mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);
            
            await _unitOfWork.MakeRepository.AsyncDelete(entity);
        }

        public async Task AsyncDeleteModel(VehicleDto vehicleDto)
        {
            var entity = AutoMapper.Mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);
            

            await _unitOfWork.ModelRepository.AsyncDelete(entity);
        }

        public async Task AsyncUpdateMake(VehicleDto vehicleDto)
        {
            var entity = AutoMapper.Mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);
            

            await _unitOfWork.MakeRepository.AsyncEdit(entity);
        }

        public async Task AsyncUpdateModel(VehicleDto vehicleDto)
        {
            var entity = AutoMapper.Mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);
            

            await _unitOfWork.ModelRepository.AsyncEdit(entity);
        }

        public async Task AsyncDetailsMake(VehicleDto vehicleDto)
        {

            var entity = AutoMapper.Mapper.Map<VehicleDto, VehicleMakeEntity>(vehicleDto);


            await _unitOfWork.MakeRepository.AsyncDetails(entity);
        }

        public async Task AsyncDetailsModel(VehicleDto vehicleDto)
        {
            var entity = AutoMapper.Mapper.Map<VehicleDto, VehicleModelEntity>(vehicleDto);


            await _unitOfWork.ModelRepository.AsyncDetails(entity);
        }

        public async Task<VehicleDto> AsyncGetMakeById(int id)
        {
            var entity = _dbContext.VehicleMake.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();

            var vehicleDto = AutoMapper.Mapper.Map<VehicleMakeEntity, VehicleDto>(entity);

            return vehicleDto;
        }

        public async Task<VehicleDto> AsyncGetModelByMakeId(int id)
        {
            var entity = _dbContext.VehicleModel.AsNoTracking().Where(x => x.MakeId == id).FirstOrDefault();

            var vehicleDto = AutoMapper.Mapper.Map<VehicleModelEntity, VehicleDto>(entity);

            return vehicleDto;
        }

        public async Task<VehicleDto> AsyncGetModelById(int id)
        {
            var entity = _dbContext.VehicleModel.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();

            var vehicleDto = AutoMapper.Mapper.Map<VehicleModelEntity, VehicleDto>(entity);

            return vehicleDto;
        }
    }
}
