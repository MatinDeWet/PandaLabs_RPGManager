namespace Application.Features.LocationFeatures.Commands.UpdateLocationParent
{
    public record UpdateLocationParentRequest(Guid Id, Guid? ParentId) : ICommand;
}
