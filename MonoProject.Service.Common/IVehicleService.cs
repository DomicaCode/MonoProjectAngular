using MonoProject.Model;
using MonoProject.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Service.Common
{
    public interface IVehicleService
    {
        Task<IEnumerable<IVehicleMakeEntity>> GetMakeAsync(int index, int count);

        Task<IEnumerable<IVehicleModelEntity>> GetModelAsync(int index, int count);

        Task InsertMakeAsync(IVehicleMakeEntity entity);
        Task InsertModelAsync(IVehicleModelEntity entity);

        Task DeleteMakeAsync(int id);
        Task DeleteModelAsync(int id);

        Task UpdateMakeAsync(IVehicleMakeEntity entity);
        Task UpdateModelAsync(IVehicleModelEntity entity);

        Task<IVehicleMakeEntity> GetMakeByIdAsync(int id);
        Task<IVehicleModelEntity> GetModelByMakeIdAsync(int id);
        Task<IVehicleModelEntity> GetModelByIdAsync(int id);
    }
}
