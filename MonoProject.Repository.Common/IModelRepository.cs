using MonoProject.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IModelRepository
    {
        Task<IVehicleModelEntity> GetModelByMakeIdAsync(int id);

        Task<IVehicleModelEntity> GetModelByIdAsync(int id);

        Task InsertAsync(IVehicleModelEntity entity);

        Task DeleteAsync(IVehicleModelEntity entity);

        Task EditAsync(IVehicleModelEntity entity);

        Task DetailsAsync(IVehicleModelEntity entity);

        Task<IEnumerable<IVehicleModelEntity>> GetAsync(int index, int count, Expression<Func<IVehicleModelEntity, int>> orderLambda);
    }
}
