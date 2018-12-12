using MonoProject.DAL;
using MonoProject.Model;
using MonoProject.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Repository
{
    public class ModelRepository : IModelRepository
    {
        ProjectDbContext context;

        public ModelRepository Current { get; set; }

        private readonly IQueryable<VehicleModelEntity> _source;

        public ModelRepository(ProjectDbContext context)
        {
            this.context = context;
            _source = this.context.VehicleModel;
        }

        public async Task AsyncDelete(VehicleModelEntity entity)
        {
            context.VehicleModel.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task AsyncInsert(VehicleModelEntity entity)
        {
            await context.VehicleModel.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task AsyncUpdate(VehicleModelEntity entity)
        {
            context.VehicleModel.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<VehicleModelEntity>> AsyncGetModel(int index, int count, Expression<Func<VehicleModelEntity, int>> orderLambda)
        {
            return _source.Skip(index * count).Take(count).OrderBy(orderLambda);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task AsyncDetails(VehicleModelEntity entity)
        {
            context.VehicleModel.Find(entity);
            await context.SaveChangesAsync();
        }
    }
}
