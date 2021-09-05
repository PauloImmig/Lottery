using Lottery.Entities.Models;
using Lottery.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Entities.UseCases
{
    public class TestUseCase
    {
        private readonly IUnitOfWork _uow;

        public TestUseCase(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void AddData()
        {
            _uow.Repository<Participant>().Insert(new Participant
            {
               Action = "asd",
               City = "asdasd",
               Country = "asdads",
               Details = "dssdaff",
               Entries = "",
               Facebook = "",
               FirstName = "",
               Instagram = "",
               LastName = "",
               Mail = "",
               Name = "",
               Region = "",
               Status = "",
               Twitter = "",
               When = DateTime.UtcNow,
               Youtube = ""
            });
        }

        public async Task AddDataAndCommit()
        {
            _uow.Repository<Participant>().Insert(new Participant
            {
                Action = "asd",
                City = "asdasd",
                Country = "asdads",
                Details = "dssdaff",
                Entries = "",
                Facebook = "",
                FirstName = "",
                Instagram = "",
                LastName = "",
                Mail = "",
                Name = "",
                Region = "",
                Status = "",
                Twitter = "",
                When = DateTime.UtcNow,
                Youtube = ""
            });
            await _uow.Commit();
        }

        public IList<Participant> GetParticipants()
        {
            return _uow.Repository<Participant>().FindAll().ToList();
        }
    }
}
