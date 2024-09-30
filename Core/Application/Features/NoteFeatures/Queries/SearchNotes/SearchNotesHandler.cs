using Application.QueryBuilders;
using Pagination;
using Pagination.Models;

namespace Application.Features.NoteFeatures.Queries.SearchNotes
{
    public class SearchNotesHandler(INoteRepository repo)
        : IQueryHandler<SearchNotesRequest, PageableResponse<SearchNotesResponse>>
    {
        public async Task<PageableResponse<SearchNotesResponse>> Handle(SearchNotesRequest request, CancellationToken cancellationToken)
        {
            var notes = await repo.QueryNoteLink(request.NoteHolder, request.NoteHolderId)
                .ApplyFilters(request)
                .Select(x => new SearchNotesResponse
                {
                    Id = x.Note.Id,
                    Title = x.Note.Title,
                    IsPrivate = x.Note.IsPrivate,
                    CreatedById = x.Note.CreatedById,
                    CreatedByName = x.Note.CreatedBy.UserName!,
                    DateTimeCreated = x.Note.DateTimeCreated
                })
                .ToPageableListAsync(request, cancellationToken);

            return notes;
        }
    }
}
