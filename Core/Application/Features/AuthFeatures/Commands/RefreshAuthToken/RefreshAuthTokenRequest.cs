namespace Application.Features.AuthFeatures.Commands.RefreshAuthToken
{
    public record RefreshAuthTokenRequest(ApplicationUser user) : ICommand<string>;
}
