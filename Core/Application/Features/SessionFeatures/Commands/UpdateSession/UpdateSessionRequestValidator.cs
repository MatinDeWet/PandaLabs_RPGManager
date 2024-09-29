namespace Application.Features.SessionFeatures.Commands.UpdateSession
{
    public class UpdateSessionRequestValidator : AbstractValidator<UpdateSessionRequest>
    {
        public UpdateSessionRequestValidator()
        {
            RuleFor(x => x.Title)
                .SetValidator(new StringInputValidator(64));

            RuleFor(x => x.Summary)
                .SetValidator(new StringInputValidator(16384, false))
                .SetValidator(new HtmlInputValidator());

            RuleFor(x => x.HouseKeeping)
                .SetValidator(new StringInputValidator(16384, false))
                .SetValidator(new HtmlInputValidator());
        }
    }
}
