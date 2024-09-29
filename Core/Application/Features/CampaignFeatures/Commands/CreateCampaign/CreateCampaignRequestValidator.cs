namespace Application.Features.CampaignFeatures.Commands.CreateCampaign
{
    public class CreateCampaignRequestValidator : AbstractValidator<CreateCampaignRequest>
    {
        public CreateCampaignRequestValidator()
        {
            RuleFor(x => x.Title)
                .SetValidator(new StringInputValidator(64));
        }
    }
}
