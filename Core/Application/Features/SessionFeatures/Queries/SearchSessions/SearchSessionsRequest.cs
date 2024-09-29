using Application.Common.Models;
using Pagination.Models;

namespace Application.Features.SessionFeatures.Queries.SearchSessions
{
    public class SearchSessionsRequest : PageableSearchRequest, IQuery<PageableResponse<SearchSessionsResponse>>
    {
        public Guid? CampaignId { get; set; }

        public bool? IsPrivate { get; set; }

        public DateRange? ScheduledDateRange { get; set; }

        public DateTimeRange? DateTimeCreatedRange { get; set; }
    }
}
