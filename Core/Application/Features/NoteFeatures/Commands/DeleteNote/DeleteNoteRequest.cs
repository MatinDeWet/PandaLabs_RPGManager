namespace Application.Features.NoteFeatures.Commands.DeleteNote
{
    public record DeleteNoteRequest(NoteHolderEnum NoteHolder, Guid Id) : ICommand;
}
