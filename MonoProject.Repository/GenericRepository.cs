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

        public GenericRepository(ProjectDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async virtual Task InsertAsync(TEntity entity)
        {
            dbSet.Add(entity);
            await context.SaveChangesAsync();
        }

        public async virtual Task DeleteAsync(TEntity entity)
        {
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async virtual Task EditAsync(TEntity entity)
        {
            dbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public async virtual Task DetailsAsync(TEntity entity)
        {
            dbSet.Find(entity);
            await context.SaveChangesAsync();
        }

        public async virtual Task<IEnumerable<TEntity>> GetAsync(int index, int count, Expression<Func<TEntity, int>> orderLambda)
        {
            return dbSet.Skip(index * count).Take(count).OrderBy(orderLambda);
        }

    }
}
