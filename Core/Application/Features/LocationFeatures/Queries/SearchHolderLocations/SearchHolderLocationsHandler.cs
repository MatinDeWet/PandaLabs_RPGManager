using Application.Features.LocationFeatures.Queries.Common;
using Application.QueryBuilders;
using Pagination;
using Pagination.Models;

namespace Application.Features.LocationFeatures.Queries.SearchHolderLocations
{
    public class SearchHolderLocationsHandler(ILocationRepository repo)
            : IQueryHandler<SearchHolderLocationsRequest, PageableResponse<SearchLocationsResponse>>
    {
        public async Task<PageableResponse<SearchLocationsResponse>> Handle(SearchHolderLocationsRequest request, CancellationToken cancellationToken)
        {
            var locations = await repo.QueryLocationLink(request.LocationHolder, request.LocationHolderId)
                .ApplyFilters(request, x => x.Location)
                .Select(x => new SearchLocationsResponse
                {
                    Id = x.Location.Id,
                    ParentId = x.Location.ParentId,
                    ParentName = x.Location.Parent!.Title ?? null!,
                    Title = x.Location.Title,
                    Type = x.Location.Type,
                    SubTypeId = x.Location.SubTypeId,
                    SubTypeName = x.Location.SubType!.Name ?? null!,
                    IsPrivate = x.Location.IsPrivate,
                    DateTimeCreated = x.Location.DateTimeCreated
                })
                .ToPageableListAsync(request, cancellationToken);

            return locations;
        }
    }
}
