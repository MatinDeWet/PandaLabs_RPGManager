namespace Application.Features.NoteFeatures.Queries.GetNoteById
{
    public class GetNoteByIdHandler(INoteRepository repo)
        : IQueryHandler<GetNoteByIdRequest, GetNoteByIdResponse>
    {
        public async Task<GetNoteByIdResponse> Handle(GetNoteByIdRequest request, CancellationToken cancellationToken)
        {
            var note = await repo.QueryNoteLink(request.NoteHolder)
                .Where(x => x.NoteId == request.Id)
                .Select(x => new GetNoteByIdResponse
                {
                    Id = x.Note.Id,
                    Title = x.Note.Title,
                    Content = x.Note.Content,
                    IsPrivate = x.Note.IsPrivate,
                    CreatedById = x.Note.CreatedById,
                    CreatedByName = x.Note.CreatedBy.UserName!,
                    DateTimeCreated = x.Note.DateTimeCreated
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (note is null)
                throw new NotFoundException(nameof(Note), request.Id);

            return note;
        }
    }
}
