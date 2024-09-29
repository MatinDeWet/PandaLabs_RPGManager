namespace Application.Features.LocationFeatures.Commands.UpdateLocation
{
    public record UpdateLocationRequest(Guid Id, string Title, string? Description) : ICommand;
}
