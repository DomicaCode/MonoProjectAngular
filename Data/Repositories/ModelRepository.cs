using Data.Context;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Repositories
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

        public async void Delete(VehicleModelEntity entity)
        {
            context.VehicleModel.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async void Insert(VehicleModelEntity entity)
        {
            await context.VehicleModel.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async void Update(VehicleModelEntity entity)
        {
            context.VehicleModel.Update(entity);
            await context.SaveChangesAsync();
        }

        public IEnumerable<VehicleModelEntity> SelectListModel(int index, int count, Expression<Func<VehicleModelEntity, int>> orderLambda)
        {
            return _source.Skip(index * count).Take(count).OrderBy(orderLambda);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async void Details(VehicleModelEntity entity)
        {
            context.VehicleModel.Find(entity);
            await context.SaveChangesAsync();
        }
    }
}
