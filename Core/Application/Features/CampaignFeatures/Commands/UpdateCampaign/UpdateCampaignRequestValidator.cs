namespace Application.Features.CampaignFeatures.Commands.UpdateCampaign
{
    public class UpdateCampaignRequestValidator : AbstractValidator<UpdateCampaignRequest>
    {
        public UpdateCampaignRequestValidator()
        {
            RuleFor(x => x.Title)
                .SetValidator(new StringValidator(64));

            RuleFor(x => x.Description)
                .SetValidator(new StringValidator(16384, false))
                .SetValidator(new HtmlInputValidator());
        }
    }
}
