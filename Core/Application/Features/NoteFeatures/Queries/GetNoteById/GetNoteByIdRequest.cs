namespace Application.Features.NoteFeatures.Queries.GetNoteById
{
    public record GetNoteByIdRequest(NoteHolderEnum NoteHolder, Guid Id) : IQuery<GetNoteByIdResponse>;
}
