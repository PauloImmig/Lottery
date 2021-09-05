using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Lottery.Infrastructure.Data
{
    public class LotteryContextFactory : IDesignTimeDbContextFactory<LotteryContext>
    {
        public LotteryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LotteryContext>();
            optionsBuilder.UseSqlServer();

            return new LotteryContext(optionsBuilder.Options);
        }
    }
}
