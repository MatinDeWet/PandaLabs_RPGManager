namespace Application.Features.SessionFeatures.Commands.ChangeSessionPrivacy
{
    public record ChangeSessionPrivacyRequest(Guid Id) : ICommand;
}
