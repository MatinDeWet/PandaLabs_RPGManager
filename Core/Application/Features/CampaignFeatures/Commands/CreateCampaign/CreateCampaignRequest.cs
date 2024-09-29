namespace Application.Features.CampaignFeatures.Commands.CreateCampaign
{
    public class CreateCampaignRequest : ICommand<CreateCampaignResponse>
    {
        public string Title { get; set; } = null!;
    }
}
