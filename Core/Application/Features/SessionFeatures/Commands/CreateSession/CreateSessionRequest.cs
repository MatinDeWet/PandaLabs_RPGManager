namespace Application.Features.SessionFeatures.Commands.CreateSession
{
    public record CreateSessionRequest(Guid CampaignId, string Title) : ICommand<CreateSessionResponse>;
}
