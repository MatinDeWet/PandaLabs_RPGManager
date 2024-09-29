namespace Application.Features.LocationFeatures.Commands.DeleteLocation
{
    public record DeleteLocationRequest(Guid Id) : ICommand;
}
