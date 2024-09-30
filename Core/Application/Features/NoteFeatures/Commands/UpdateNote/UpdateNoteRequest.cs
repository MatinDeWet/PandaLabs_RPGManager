namespace Application.Features.NoteFeatures.Commands.UpdateNote
{
    public record UpdateNoteRequest(NoteHolderEnum NoteHolder, Guid Id, string Title, string Content) : ICommand;
}
