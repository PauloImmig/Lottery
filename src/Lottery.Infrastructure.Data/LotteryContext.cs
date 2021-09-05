using Lottery.Entities.Models;
using Lottery.Infrastructure.Data.Repositories;
using Lottery.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lottery.Infrastructure.Data
{
    public class LotteryContext : DbContext, IUnitOfWork
    {
        private Dictionary<string, dynamic> _repositories;

        public LotteryContext(DbContextOptions opts) : base(opts) { }

        public DbSet<Participant> Participants { get; set; }

        public async Task<bool> Commit() => await SaveChangesAsync() > 0;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfigurationsFromAssembly(assembly: System.Reflection.Assembly.GetAssembly(typeof(LotteryContext)));

            base.OnModelCreating(modelBuilder);
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : IAggregateRoot
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, dynamic>();
            var type = typeof(TEntity).Name;
            if (_repositories.ContainsKey(type))
                return (IRepository<TEntity>)_repositories[type];
            var repositoryType = typeof(Repository<>);
            _repositories.Add(type, Activator.CreateInstance(
                repositoryType.MakeGenericType(typeof(TEntity)), this)
            );
            return _repositories[type];
        }
    }
}
