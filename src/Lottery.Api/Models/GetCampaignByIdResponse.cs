using System;

namespace Lottery.Api.Models
{
    public class GetCampaignByIdResponse
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string EmailSubject { get; set; }
        public string EmailContent { get; set; }
        public string[] EmailPlaceholders { get; set; }
    }
}
