using Lottery.SharedKernel.Interfaces;
using Lottery.SharedKernel;
using System;
using System.Collections.Generic;
using Lottery.Entities.Models;
using System.Collections.ObjectModel;

namespace Lottery.Domain.Entities
{
    public class Campaign : Entity, IAggregateRoot
    {
        private Campaign()
        { }

        public Campaign(CampaignPeriod period, string name, string description)
        {
            Period = period;
            Name = name;
            Description = description;
        }

        public CampaignPeriod Period { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public virtual CampaignEmailTemplate EmailTemplate { get; private set; }

        public bool Active { get; private set; } = true;

        private ICollection<Participant> _participants = new List<Participant>();
        public virtual IReadOnlyCollection<Participant> Participants
        {
            get
            {
                return (IReadOnlyCollection<Participant>)_participants;
            }
            private set
            {
                _participants = (ICollection<Participant>)value;
            }
        }
        public void SetEmailTemplate(CampaignEmailTemplate emailTemplate) => EmailTemplate = emailTemplate;

        public void Activate() => Active = true;

        public void Inactivate() => Active = false;
    }

    public class CampaignPeriod
    {
        private CampaignPeriod()
        {

        }

        public CampaignPeriod(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate) throw new ArgumentException($"{nameof(startDate)} should be greater than {nameof(endDate)}");

            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }
    }
}
