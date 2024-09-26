namespace Application.Features.SessionFeatures.Commands.CreateSession
{
    public class CreateSessionRequestValidator : AbstractValidator<CreateSessionRequest>
    {
        public CreateSessionRequestValidator()
        {
            RuleFor(x => x.Title)
                .SetValidator(new StringValidator(64));
        }
    }
}
