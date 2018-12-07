using Data.Context;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Data.Entities;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class MakeRepository : IMakeRepository
    {
        ProjectDbContext context;

        public MakeRepository Current { get; set; }

        private readonly IQueryable<VehicleMakeEntity> _source;

        public MakeRepository(ProjectDbContext context)
        {
            this.context = context;
            _source = this.context.VehicleMake;
        }

        public async Task Delete(VehicleMakeEntity entity)
        {
             context.VehicleMake.Remove(entity);
             await context.SaveChangesAsync();
        }

        public async Task Insert(VehicleMakeEntity entity)
        {
            context.VehicleMake.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(VehicleMakeEntity entity)
        {
            context.VehicleMake.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task Details(VehicleMakeEntity entity)
        {
            context.VehicleMake.Find(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<VehicleMakeEntity>> SelectListMake(int index, int count, Expression<Func<VehicleMakeEntity, int>> orderLambda)
        {
            return _source.Skip(index * count).Take(count).OrderBy(orderLambda);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
