namespace Application.Features.LocationFeatures.Commands.CreateLocation
{
    public class CreateLocationRequestValidator : AbstractValidator<CreateLocationRequest>
    {
        public CreateLocationRequestValidator()
        {
            RuleFor(x => x.Title)
                .SetValidator(new StringInputValidator(64));

            RuleFor(x => x.Type)
                .IsInEnum();
        }
    }
}
