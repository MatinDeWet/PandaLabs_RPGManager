using Application.Common.Models;
using Pagination.Models;

namespace Application.Features.NoteFeatures.Queries.SearchNotes
{
    public class SearchNotesRequest : PageableSearchRequest, IQuery<PageableResponse<SearchNotesResponse>>
    {
        public NoteHolderEnum NoteHolder { get; set; }

        public Guid? NoteHolderId { get; set; }

        public bool? IsPrivate { get; set; }

        public int? CreatedById { get; set; }

        public DateTimeRange? DateTimeCreatedRange { get; set; }
    }
}
