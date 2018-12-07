using Data.Entities;
using EntityFrameworkPaginateCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleDto>> GetMake(int index, int count);

        Task<IEnumerable<VehicleDto>> GetModel(int index, int count);

        Task InsertMake(VehicleDto entity);
        Task InsertModel(VehicleDto entity);

        Task DeleteMake(VehicleDto entity);
        Task DeleteModel(VehicleDto entity);

        Task UpdateMake(VehicleDto entity);
        Task UpdateModel(VehicleDto entity);

        Task<VehicleDto> GetMakeById(int id);
        Task<VehicleDto> GetModelByMakeId(int id);
        Task<VehicleDto> GetModelById(int id);
    }
}
