using System;

namespace Lottery.Api.Models
{
    public class CreateCampaignResponse
    {
        public Guid Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
