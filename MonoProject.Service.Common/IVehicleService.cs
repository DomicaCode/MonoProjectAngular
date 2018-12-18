using MonoProject.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Service.Common
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleDto>> GetMakeAsync(int index, int count);

        Task<IEnumerable<VehicleDto>> GetModelAsync(int index, int count);

        Task InsertMakeAsync(VehicleDto entity);
        Task InsertModelAsync(VehicleDto entity);

        Task DeleteMakeAsync(VehicleDto entity);
        Task DeleteModelAsync(VehicleDto entity);

        Task UpdateMakeAsync(VehicleDto entity);
        Task UpdateModelAsync(VehicleDto entity);

        Task<VehicleDto> GetMakeByIdAsync(int id);
        Task<VehicleDto> GetModelByMakeIdAsync(int id);
        Task<VehicleDto> GetModelByIdAsync(int id);
    }
}
