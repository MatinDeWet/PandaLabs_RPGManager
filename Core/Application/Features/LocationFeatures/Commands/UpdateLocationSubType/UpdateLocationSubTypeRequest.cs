namespace Application.Features.LocationFeatures.Commands.UpdateLocationSubType
{
    public record UpdateLocationSubTypeRequest(Guid Id, int? SubTypeId) : ICommand;
}
