using MonoProject.Model;
using MonoProject.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IMakeRepository
    {
        Task<IVehicleMakeEntity> GetMakeByIdAsync(int id);

        Task InsertAsync(IVehicleMakeEntity entity);

        Task DeleteAsync(IVehicleMakeEntity entity);

        Task EditAsync(IVehicleMakeEntity entity);

        Task DetailsAsync(IVehicleMakeEntity entity);

        Task<IEnumerable<IVehicleMakeEntity>> GetAsync(int index, int count, Expression<Func<IVehicleMakeEntity, int>> orderLambda);
    }
}
