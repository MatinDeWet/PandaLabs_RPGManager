using Pagination.Models;

namespace Application.Features.LocationFeatures.Queries.SearchHolderLocations
{
    public class SearchHolderLocationsRequest : PageableRequest, IQuery<PageableResponse<SearchHolderLocationsResponse>>
    {
        public Guid? LocationHolderId { get; set; }

        public LocationHolderEnum LocationHolder { get; set; }
    }
}
