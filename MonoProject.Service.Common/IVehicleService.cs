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
        Task<IEnumerable<VehicleDto>> AsyncGetMake(int index, int count);

        Task<IEnumerable<VehicleDto>> GetModel(int index, int count);

        Task AsyncInsertMake(VehicleDto entity);
        Task AsyncInsertModel(VehicleDto entity);

        Task AsyncDeleteMake(VehicleDto entity);
        Task AsyncDeleteModel(VehicleDto entity);

        Task AsyncUpdateMake(VehicleDto entity);
        Task AsyncUpdateModel(VehicleDto entity);

        Task<VehicleDto> AsyncGetMakeById(int id);
        Task<VehicleDto> AsyncGetModelByMakeId(int id);
        Task<VehicleDto> AsyncGetModelById(int id);
    }
}
