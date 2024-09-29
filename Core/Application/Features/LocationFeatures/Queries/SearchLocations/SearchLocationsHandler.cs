using Application.QueryBuilders;
using Pagination;
using Pagination.Models;

namespace Application.Features.LocationFeatures.Queries.SearchLocations
{
    public class SearchLocationsHandler(ILocationRepository repo)
            : IQueryHandler<SearchLocationsRequest, PageableResponse<SearchLocationsResponse>>
    {
        public async Task<PageableResponse<SearchLocationsResponse>> Handle(SearchLocationsRequest request, CancellationToken cancellationToken)
        {
            var locations = await repo.Locations
                .ApplyFilters(request)
                .Select(x => new SearchLocationsResponse
                {
                    Id = x.Id,
                    CampaignId = x.CampaignId,
                    CampaignName = x.Campaign.Title,
                    ParentId = x.ParentId,
                    ParentName = x.Parent!.Title ?? null!,
                    Title = x.Title,
                    Type = x.Type,
                    SubTypeId = x.SubTypeId,
                    SubTypeName = x.SubType!.Name ?? null!,
                    IsPrivate = x.IsPrivate,
                    DateTimeCreated = x.DateTimeCreated
                })
                .ToPageableListAsync(request, cancellationToken);

            return locations;
        }
    }
}
