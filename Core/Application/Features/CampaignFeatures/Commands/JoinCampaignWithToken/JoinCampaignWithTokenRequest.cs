namespace Application.Features.CampaignFeatures.Commands.JoinCampaignWithToken
{
    public record JoinCampaignWithTokenRequest(string Token) : ICommand;
}
