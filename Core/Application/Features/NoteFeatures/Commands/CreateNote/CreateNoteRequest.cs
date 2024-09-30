namespace Application.Features.NoteFeatures.Commands.CreateNote
{
    public record CreateNoteRequest(Guid HolderId, NoteHolderEnum NoteHolder, string Title, string Content) : ICommand<CreateNoteResponse>;
}
