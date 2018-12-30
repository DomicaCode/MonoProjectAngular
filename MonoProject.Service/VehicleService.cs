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
using Ninject;
using MonoProject.Model.Interfaces;
using MonoProject.Repository.Common;

namespace MonoProject.Service
{
    public class VehicleService : IVehicleService
    {


        private IUnitOfWork _unitOfWork;
        private IMakeRepository _makeRepository;
        private IModelRepository _modelRepository;



        public VehicleService(IUnitOfWork unitOfWork, IMakeRepository makeRepository, IModelRepository modelRepository)
        {
            _unitOfWork = unitOfWork;
            _makeRepository = makeRepository;
            _modelRepository = modelRepository;
        }


        public async Task<IEnumerable<IVehicleMakeEntity>> GetMakeAsync(int index, int count)
        {
            var data =  await _makeRepository.GetAsync(index, count, p => p.Id);

            return data;
        }
        
        public async Task<IEnumerable<IVehicleModelEntity>> GetModelAsync(int index, int count)
        {
            var data = await _modelRepository.GetAsync(index, count, p => p.Id);

            return data;
        }
        
        public async Task InsertMakeAsync(IVehicleMakeEntity vehicleMake)
        {
            
             await _makeRepository.InsertAsync(vehicleMake);
        }

        public async Task InsertModelAsync(IVehicleModelEntity vehicleModel)
        {

            await _modelRepository.InsertAsync(vehicleModel);
        }

        public async Task DeleteMakeAsync(int id)
        {
            var vehicle = await _makeRepository.GetMakeByIdAsync(id);

            await _makeRepository.DeleteAsync(vehicle);
        }

        public async Task DeleteModelAsync(int id)
        {
            var vehicle = await _modelRepository.GetModelByIdAsync(id);

            await _modelRepository.DeleteAsync(vehicle);
        }

        public async Task UpdateMakeAsync(IVehicleMakeEntity vehicleMake)
        {

            await _makeRepository.EditAsync(vehicleMake);
        }

        public async Task UpdateModelAsync(IVehicleModelEntity vehicleModel)
        {
            
            await _modelRepository.EditAsync(vehicleModel);
        }

        public async Task<IVehicleMakeEntity> GetMakeByIdAsync(int id)
        {
            var data = await _makeRepository.GetMakeByIdAsync(id);

            return data;
        }

        public async Task<IVehicleModelEntity> GetModelByMakeIdAsync(int id)
        {
            var data = await _modelRepository.GetModelByMakeIdAsync(id);

            return data;
        }
        public async Task<IVehicleModelEntity> GetModelByIdAsync(int id)
        {
            var data = await _modelRepository.GetModelByIdAsync(id);

            return data;
        }



        /*
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
        */

    }
}
