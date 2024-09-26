namespace Application.Common.Validation
{
    public class StringValidator : AbstractValidator<string?>
    {
        public StringValidator(int maxLength, bool isRequired = true)
        {
            if (isRequired)
            {
                RuleFor(x => x)
                    .NotEmpty()
                    .WithMessage("{PropertyName} is required.");
            }

            RuleFor(x => x)
                .MaximumLength(maxLength)
                .WithMessage("{PropertyName} must not exceed {MaxLength} characters.");
        }

        public StringValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");
        }
    }
}
