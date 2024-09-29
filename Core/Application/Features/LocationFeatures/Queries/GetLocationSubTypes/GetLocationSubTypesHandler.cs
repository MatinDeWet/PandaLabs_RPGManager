using Application.Common.Models;

namespace Application.Features.LocationFeatures.Queries.GetLocationSubTypes
{
    public class GetLocationSubTypesHandler(ILocationSubTypeRepository repo)
            : IRequestHandler<GetLocationSubTypesRequest, List<BasicList>>
    {
        public async Task<List<BasicList>> Handle(GetLocationSubTypesRequest request, CancellationToken cancellationToken)
        {
            var locationSubTypes = await repo.LocationSubTypes
                .Where(x => x.Group == request.LocationType)
                .Select(x => new BasicList
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync(cancellationToken);

            return locationSubTypes;
        }
    }
}
