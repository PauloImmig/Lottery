namespace Lottery.Api.Models
{
    public class SetCampaignEmailTemplateRequest
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string[] Placeholders { get; set; }
    }
}
