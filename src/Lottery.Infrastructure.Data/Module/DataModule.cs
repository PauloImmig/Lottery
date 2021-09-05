using Lottery.Domain.Interfaces;
using Lottery.Infrastructure.Data;
using Lottery.Infrastructure.Data.Repositories;
using Lottery.SharedKernel.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Lotter.Infrastructurey.Data.Module
{
    public static class DataModule
    {
        public static void AddDataModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IParticipantRepository, ParticipantRepository>();
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped<IUnitOfWork, LotteryContext>();
        }
    }
}
