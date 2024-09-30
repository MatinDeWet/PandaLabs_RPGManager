using Application.Features.LocationFeatures.Queries.Common;
using Application.Features.LocationFeatures.Queries.SearchLocations;
using Pagination.Models;

namespace Application.Features.LocationFeatures.Queries.SearchHolderLocations
{
    public class SearchHolderLocationsRequest : SearchLocationsRequest, IQuery<PageableResponse<SearchLocationsResponse>>
    {
        public Guid? LocationHolderId { get; set; }

        public LocationHolderEnum LocationHolder { get; set; }
    }
}
