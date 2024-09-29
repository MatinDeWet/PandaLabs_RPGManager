namespace Application.Features.LocationFeatures.Queries.GetLocationById
{
    public class GetLocationByIdHandler(ILocationRepository repo)
            : IQueryHandler<GetLocationByIdRequest, GetLocationByIdResponse>
    {
        public async Task<GetLocationByIdResponse> Handle(GetLocationByIdRequest request, CancellationToken cancellationToken)
        {
            var location = await repo.Locations
                .Where(l => l.Id == request.Id)
                .Select(x => new GetLocationByIdResponse
                {
                    Id = x.Id,
                    CampaignId = x.CampaignId,
                    CampaignName = x.Campaign.Title,
                    ParentId = x.ParentId,
                    ParentName = x.Parent!.Title ?? null!,
                    Title = x.Title,
                    Description = x.Description,
                    Type = x.Type,
                    SubTypeId = x.SubTypeId,
                    SubTypeName = x.SubType!.Name ?? null!,
                    IsPrivate = x.IsPrivate,
                    DateTimeCreated = x.DateTimeCreated,
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (location is null)
                throw new NotFoundException(nameof(Location), request.Id);

            return location;
        }
    }
}
