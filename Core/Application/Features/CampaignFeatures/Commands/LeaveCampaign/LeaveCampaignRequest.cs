namespace Application.Features.CampaignFeatures.Commands.LeaveCampaign
{
    public record LeaveCampaignRequest(Guid Id) : ICommand;
}
