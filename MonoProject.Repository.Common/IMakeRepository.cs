using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MonoProject.Model;

namespace MonoProject.Repository.Common
{
    public interface IMakeRepository : IDisposable
    {
        Task AsyncInsert(VehicleMakeEntity entity);

        Task AsyncUpdate(VehicleMakeEntity entity);

        Task AsyncDelete(VehicleMakeEntity entity);

        Task<IEnumerable<VehicleMakeEntity>> AsyncGetMake(int index, int count, Expression<Func<VehicleMakeEntity, int>> orderLambda);

        Task AsyncDetails(VehicleMakeEntity entity);
    }
}
