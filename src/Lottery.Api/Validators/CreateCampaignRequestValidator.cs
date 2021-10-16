using FluentValidation;
using Lottery.Api.Models;
using System;

namespace Lottery.Api.Validators
{
    public class CreateCampaignRequestValidator : AbstractValidator<CreateCampaignRequest>
    {
        public CreateCampaignRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(5);
            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate);
        }
    }
}

