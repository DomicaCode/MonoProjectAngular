using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IGenericRepository<TEntity>
    {
        Task AsyncInsert(TEntity entity);
        Task AsyncDelete(TEntity entity);
        Task AsyncEdit(TEntity entity);
        Task AsyncDetails(TEntity entity);
        Task<IEnumerable<TEntity>> AsyncGet(int index, int count, Expression<Func<TEntity, int>> orderLambda);
    }
}
