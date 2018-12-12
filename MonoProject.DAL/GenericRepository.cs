using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.DAL
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal ProjectDbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(ProjectDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async virtual Task AsyncInsert(TEntity entity)
        {
            dbSet.Add(entity);
            await context.SaveChangesAsync();
        }

        public async virtual Task AsyncDelete(TEntity entity)
        {
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async virtual Task AsyncEdit(TEntity entity)
        {
            dbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public async virtual Task AsyncDetails(TEntity entity)
        {
            dbSet.Find(entity);
            await context.SaveChangesAsync();
        }

        public async virtual Task<IEnumerable<TEntity>> AsyncGet(int index, int count, Expression<Func<TEntity, int>> orderLambda)
        {
            return dbSet.Skip(index * count).Take(count).OrderBy(orderLambda);
        }
    }
}
