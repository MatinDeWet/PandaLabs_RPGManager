namespace Application.Features.LocationFeatures.Commands.CreateLocation
{
    public record CreateLocationRequest(Guid CampaignId, string Title, LocationTypeEnum Type) : ICommand<CreateLocationResponse>;
}
