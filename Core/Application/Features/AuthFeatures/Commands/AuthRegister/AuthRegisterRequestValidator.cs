namespace Application.Features.AuthFeatures.Commands.AuthRegister
{
    public class AuthRegisterRequestValidator : AbstractValidator<AuthRegisterRequest>
    {
        public AuthRegisterRequestValidator()
        {
            RuleFor(x => x.Email)
                .SetValidator(new StringValidator())
                .EmailAddress()
                .WithMessage("{PropertyName} is not valid");

            RuleFor(x => x.Password)
                .SetValidator(new StringValidator());

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage("{PropertyName} does not match");
        }
    }
}
