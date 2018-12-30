using Microsoft.EntityFrameworkCore;
using MonoProject.DAL;
using MonoProject.Model;
using MonoProject.Model.Interfaces;
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
        protected internal ProjectDbContext _context;
        protected internal IGenericRepository<IVehicleModelEntity> _genModel;


        public ModelRepository(ProjectDbContext context, IGenericRepository<IVehicleModelEntity> genModel)
        {
            _context = context;
            _genModel = genModel;
        }

        public async Task<IVehicleModelEntity> GetModelByMakeIdAsync(int id)
        {
            var entity = _context.VehicleModel.AsNoTracking().Where(x => x.MakeId == id).FirstOrDefault();

            return entity;
        }

        public async Task<IVehicleModelEntity> GetModelByIdAsync(int id)
        {
            var entity = _context.VehicleModel.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();

            return entity;
        }

        public async Task InsertAsync(IVehicleModelEntity entity)
        {
            await _genModel.InsertAsync(entity);
        }

        public async Task DeleteAsync(IVehicleModelEntity entity)
        {
            await _genModel.DeleteAsync(entity);
        }

        public async Task EditAsync(IVehicleModelEntity entity)
        {
            await _genModel.EditAsync(entity);
        }

        public async Task DetailsAsync(IVehicleModelEntity entity)
        {
            await _genModel.DetailsAsync(entity);
        }

        public async Task<IEnumerable<IVehicleModelEntity>> GetAsync(int index, int count, Expression<Func<IVehicleModelEntity, int>> orderLambda)
        {
            return _context.VehicleModel.Skip(index * count).Take(count).OrderBy(orderLambda);
        }
    }
}
