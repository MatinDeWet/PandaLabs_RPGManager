namespace Application.Features.LocationFeatures.Queries.GetLocationById
{
    public record GetLocationByIdRequest(Guid Id) : IQuery<GetLocationByIdResponse>;
}
