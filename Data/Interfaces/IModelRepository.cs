using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IModelRepository : IDisposable
    {
        Task Insert(VehicleModelEntity entity);

        Task Update(VehicleModelEntity entity);

        Task Delete(VehicleModelEntity entity);

        Task<IEnumerable<VehicleModelEntity>> SelectListModel(int index, int count, Expression<Func<VehicleModelEntity, int>> orderLambda);

        Task Details(VehicleModelEntity entity);
    }
}
