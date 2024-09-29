namespace Application.Features.CampaignFeatures.Commands.DeleteCampaign
{
    public record DeleteCampaignRequest(Guid Id) : ICommand;
}
