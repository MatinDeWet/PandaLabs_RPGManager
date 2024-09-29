namespace Application.Features.CampaignFeatures.Commands.RefreshCampaignToken
{
    public record RefreshCampaignTokenRequest(Guid Id) : ICommand;
}
