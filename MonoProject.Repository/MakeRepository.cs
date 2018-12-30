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
    public class MakeRepository : IMakeRepository
    {
        protected internal IGenericRepository<IVehicleMakeEntity> _genMake;
        protected internal ProjectDbContext _context;

        public MakeRepository(ProjectDbContext context, IGenericRepository<IVehicleMakeEntity> genMake)
        {
            _context = context;
            _genMake = genMake;
        }

        public async Task InsertAsync(IVehicleMakeEntity entity)
        {
            await _genMake.InsertAsync(entity);
        }

        public async Task DeleteAsync(IVehicleMakeEntity entity)
        {
            await _genMake.DeleteAsync(entity);
        }

        public async Task EditAsync(IVehicleMakeEntity entity)
        {
            await _genMake.EditAsync(entity);
        }

        public async Task DetailsAsync(IVehicleMakeEntity entity)
        {
            await _genMake.DetailsAsync(entity);
        }

        public async Task<IEnumerable<IVehicleMakeEntity>> GetAsync(int index, int count, Expression<Func<IVehicleMakeEntity, int>> orderLambda)
        {
            return _context.VehicleMake.Skip(index * count).Take(count).OrderBy(orderLambda);
        }

        public async Task<IVehicleMakeEntity> GetMakeByIdAsync(int id)
        {
            var entity = _context.VehicleMake.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();

            return entity;
        }
    }
}
