using Application.Common.Models;

namespace Application.Features.LocationFeatures.Queries.GetLocationSubTypes
{
    public record GetLocationSubTypesRequest(LocationTypeEnum LocationType) : IQuery<List<BasicList>>;
}
