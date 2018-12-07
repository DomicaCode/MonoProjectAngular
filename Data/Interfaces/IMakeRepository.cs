using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Interfaces
{
    public interface IMakeRepository : IDisposable
    {
        Task Insert(VehicleMakeEntity entity);

        Task Update(VehicleMakeEntity entity);

        Task Delete(VehicleMakeEntity entity);

        Task<IEnumerable<VehicleMakeEntity>> SelectListMake(int index, int count, Expression<Func<VehicleMakeEntity, int>> orderLambda);

        Task Details(VehicleMakeEntity entity);
    }
}
