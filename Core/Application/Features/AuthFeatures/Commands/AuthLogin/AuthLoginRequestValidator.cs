namespace Application.Features.AuthFeatures.Commands.AuthLogin
{
    public class AuthLoginRequestValidator : AbstractValidator<AuthLoginRequest>
    {
        public AuthLoginRequestValidator()
        {
            RuleFor(x => x.Email)
                .SetValidator(new StringValidator())
                .EmailAddress()
                .WithMessage("{PropertyName} is not valid");

            RuleFor(x => x.Password)
                .SetValidator(new StringValidator());
        }
    }
}
