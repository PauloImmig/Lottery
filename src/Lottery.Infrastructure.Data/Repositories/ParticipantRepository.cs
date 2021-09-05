using Lottery.Domain.Interfaces;
using Lottery.Entities.Models;

namespace Lottery.Infrastructure.Data.Repositories
{
    public class ParticipantRepository : Repository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(LotteryContext context) : base(context)
        { }
    }
}
