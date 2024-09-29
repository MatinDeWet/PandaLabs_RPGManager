using Pagination.Models;

namespace Application.Features.LocationFeatures.Queries.SearchLocations
{
    public class SearchLocationsRequest : PageableSearchRequest, IQuery<PageableResponse<SearchLocationsResponse>>
    {
        public Guid? CampaignId { get; set; }

        public Guid? ParentId { get; set; }

        public LocationTypeEnum? Type { get; set; }

        public int? SubTypeId { get; set; }
    }
}
