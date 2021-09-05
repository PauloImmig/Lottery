using Lottery.SharedKernel.Interfaces;
using System.Threading.Tasks;

namespace Lottery.SharedKernel.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        IRepository<TEntity> Repository<TEntity>() where TEntity : IAggregateRoot;
    }
}