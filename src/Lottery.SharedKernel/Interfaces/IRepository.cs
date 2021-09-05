using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.SharedKernel.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        TEntity Find(params object[] keyValues);
        IEnumerable<TEntity> FindAll();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IQueryable<TEntity> Queryable();
    }
}
