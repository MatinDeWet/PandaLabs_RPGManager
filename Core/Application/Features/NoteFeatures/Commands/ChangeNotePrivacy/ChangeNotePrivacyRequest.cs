namespace Application.Features.NoteFeatures.Commands.ChangeNotePrivacy
{
    public record ChangeNotePrivacyRequest(NoteHolderEnum NoteHolder, Guid Id) : ICommand;
}
