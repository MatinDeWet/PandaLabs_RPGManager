namespace Application.Features.NoteFeatures.Commands.CreateNote
{
    public class CreateNoteRequestValidator : AbstractValidator<CreateNoteRequest>
    {
        public CreateNoteRequestValidator()
        {
            RuleFor(x => x.Title)
                .SetValidator(new StringInputValidator(64));

            RuleFor(x => x.Content)
                .SetValidator(new StringInputValidator(8192))
                .SetValidator(new HtmlInputValidator());
        }
    }
}
