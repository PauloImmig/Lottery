using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lottery.SharedKernel.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        TEntity Find(params object[] keyValues);
        IEnumerable<TEntity> FindAll();
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        IQueryable<TEntity> Queryable();
        IQueryable<TEntity> Queryable<TProperty>(Expression<Func<TEntity, TProperty>> navigationPropertyPath);
    }
}
