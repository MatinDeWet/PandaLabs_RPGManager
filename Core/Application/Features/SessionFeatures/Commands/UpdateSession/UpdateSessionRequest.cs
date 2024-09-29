namespace Application.Features.SessionFeatures.Commands.UpdateSession
{
    public record UpdateSessionRequest(Guid Id, string Title, string? Summary, string? HouseKeeping, DateOnly? ScheduledDate) : ICommand;
}
