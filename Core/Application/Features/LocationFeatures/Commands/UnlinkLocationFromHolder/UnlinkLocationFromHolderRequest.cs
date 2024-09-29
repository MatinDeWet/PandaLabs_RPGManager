namespace Application.Features.LocationFeatures.Commands.UnlinkLocationFromHolder
{
    public record UnlinkLocationFromHolderRequest(LocationHolderEnum LocationHolder, Guid LocationHolderId, Guid LocationId) : ICommand;
}
