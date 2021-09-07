using Lottery.SharedKernel.Interfaces;
using Lottery.SharedKernel;
using System;

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

        public void SetEmailTemplate(CampaignEmailTemplate emailTemplate)
        {
            EmailTemplate = emailTemplate;
        }
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
