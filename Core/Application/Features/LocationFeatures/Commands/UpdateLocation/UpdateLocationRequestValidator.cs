namespace Application.Features.LocationFeatures.Commands.UpdateLocation
{
    public class UpdateLocationRequestValidator : AbstractValidator<UpdateLocationRequest>
    {
        public UpdateLocationRequestValidator()
        {
            RuleFor(x => x.Title)
                .SetValidator(new StringInputValidator(64));

            RuleFor(x => x.Description)
                .SetValidator(new StringInputValidator(16384, false))
                .SetValidator(new HtmlInputValidator());
        }
    }
}
