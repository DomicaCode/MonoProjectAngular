using Microsoft.EntityFrameworkCore;
using MonoProject.DAL;
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
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal ProjectDbContext context;
        internal DbSet<TEntity> dbSet;
        internal IUnitOfWork _uow;

        public GenericRepository(ProjectDbContext context, IUnitOfWork uow)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
            _uow = uow;
        }

        public async virtual Task InsertAsync(TEntity entity)
        {
            dbSet.Add(entity);
            await _uow.Commit(entity);
        }

        public async virtual Task DeleteAsync(TEntity entity)
        {
            dbSet.Remove(entity);
            await _uow.Commit(entity);
        }

        public async virtual Task EditAsync(TEntity entity)
        {
            dbSet.Update(entity);
            await _uow.Commit(entity);
        }

        public async virtual Task DetailsAsync(TEntity entity)
        {
            dbSet.Find(entity);
            await _uow.Commit(entity);
        }

        public async virtual Task<IEnumerable<TEntity>> GetAsync(int index, int count, Expression<Func<TEntity, int>> orderLambda)
        {
            return dbSet.Skip(index * count).Take(count).OrderBy(orderLambda);
        }

    }
}
