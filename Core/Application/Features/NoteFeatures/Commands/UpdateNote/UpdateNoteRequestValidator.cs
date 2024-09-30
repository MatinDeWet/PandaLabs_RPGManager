namespace Application.Features.NoteFeatures.Commands.UpdateNote
{
    public class UpdateNoteRequestValidator : AbstractValidator<UpdateNoteRequest>
    {
        public UpdateNoteRequestValidator()
        {
            RuleFor(x => x.Title)
                .SetValidator(new StringInputValidator(64));

            RuleFor(x => x.Content)
                .SetValidator(new StringInputValidator(8192))
                .SetValidator(new HtmlInputValidator());
        }
    }
}
