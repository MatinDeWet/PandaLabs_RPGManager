namespace Application.Features.SessionFeatures.Queries.GetSessionById
{
    public record GetSessionByIdRequest(Guid Id) : IQuery<GetSessionByIdResponse>;
}
