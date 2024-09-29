namespace Application.Features.SessionFeatures.Commands.DeleteSession
{
    public record DeleteSessionRequest(Guid Id) : ICommand;
}
