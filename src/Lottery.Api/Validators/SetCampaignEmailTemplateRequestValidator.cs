using FluentValidation;
using Lottery.Api.Models;
using System.Linq;

namespace Lottery.Api.Validators
{
    public class SetCampaignEmailTemplateRequestValidator : AbstractValidator<SetCampaignEmailTemplateRequest>
    {
        public SetCampaignEmailTemplateRequestValidator()
        {
            RuleFor(x => x.Subject)
                .NotEmpty()
                .MinimumLength(5);
            RuleFor(x => x.Content)
                .NotEmpty()
                .MinimumLength(5);
            RuleFor(x => x.Placeholders)
                .Must(y => y.Distinct().Count() == y.Length)
                .WithMessage("One or more items in Placeholders collection items are duplicates");

        }
    }
}