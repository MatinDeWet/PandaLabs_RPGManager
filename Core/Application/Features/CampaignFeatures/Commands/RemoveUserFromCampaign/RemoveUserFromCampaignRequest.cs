namespace Application.Features.CampaignFeatures.Commands.RemoveUserFromCampaign
{
    public record RemoveUserFromCampaignRequest(Guid CampaignId, int UserId) : ICommand;
}
