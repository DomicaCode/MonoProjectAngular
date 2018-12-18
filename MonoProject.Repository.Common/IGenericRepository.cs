using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IGenericRepository<TEntity>
    {
        Task InsertAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task EditAsync(TEntity entity);
        Task DetailsAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAsync(int index, int count, Expression<Func<TEntity, int>> orderLambda);
    }
}
