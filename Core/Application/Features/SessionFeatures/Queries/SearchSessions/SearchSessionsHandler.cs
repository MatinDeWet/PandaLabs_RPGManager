using Application.QueryBuilders;
using Pagination;
using Pagination.Models;

namespace Application.Features.SessionFeatures.Queries.SearchSessions
{
    public class SearchSessionsHandler(ISessionRepository repo)
            : IQueryHandler<SearchSessionsRequest, PageableResponse<SearchSessionsResponse>>
    {
        public async Task<PageableResponse<SearchSessionsResponse>> Handle(SearchSessionsRequest request, CancellationToken cancellationToken)
        {
            var sessions = await repo.Sessions
                .ApplyFilters(request)
                .Select(x => new SearchSessionsResponse
                {
                    Id = x.Id,
                    CampaignId = x.CampaignId,
                    CampaignTitle = x.Campaign.Title,
                    Title = x.Title,
                    IsPrivate = x.IsPrivate,
                    ScheduledDate = x.ScheduledDate,
                    DateTimeCreated = x.DateTimeCreated
                })
                .ToPageableListAsync(request, cancellationToken);

            return sessions;
        }
    }
}
