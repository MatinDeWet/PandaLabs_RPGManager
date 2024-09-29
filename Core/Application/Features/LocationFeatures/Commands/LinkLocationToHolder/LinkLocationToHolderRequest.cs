namespace Application.Features.LocationFeatures.Commands.LinkLocationToHolder
{
    public record LinkLocationToHolderRequest(LocationHolderEnum LocationHolder, Guid LocationHolderId, Guid LocationId) : ICommand;
}
