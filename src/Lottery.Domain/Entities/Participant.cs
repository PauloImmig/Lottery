using Lottery.SharedKernel;
using Lottery.SharedKernel.Interfaces;
using System;

namespace Lottery.Entities.Models
{
    public class Participant : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
        public string Entries { get; set; }
        public string Details { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public DateTime When { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
    }
}
