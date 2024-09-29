using Application.Common.Models;
using Pagination.Models;

namespace Application.Features.CampaignFeatures.Queries.SearchCampaigns
{
    public class SearchCampaignsRequest : PageableSearchRequest, IQuery<PageableResponse<SearchCampaignsResponse>>
    {
        public CampaignRoleEnum? Role { get; set; }

        public DateTimeRange? DateTimeCreatedRange { get; set; }
    }
}
