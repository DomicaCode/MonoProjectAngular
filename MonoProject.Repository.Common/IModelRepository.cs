using MonoProject.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IModelRepository : IDisposable
    {
        Task AsyncInsert(VehicleModelEntity entity);

        Task AsyncUpdate(VehicleModelEntity entity);

        Task AsyncDelete(VehicleModelEntity entity);

        Task<IEnumerable<VehicleModelEntity>> AsyncGetModel(int index, int count, Expression<Func<VehicleModelEntity, int>> orderLambda);

        Task AsyncDetails(VehicleModelEntity entity);
    }
}
