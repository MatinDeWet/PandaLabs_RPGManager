namespace Application.Features.SessionFeatures.Queries.GetSessionById
{
    public class GetSessionByIdHandler(ISessionRepository repo, IIdentityInfo identityInfo)
            : IQueryHandler<GetSessionByIdRequest, GetSessionByIdResponse>
    {
        public async Task<GetSessionByIdResponse> Handle(GetSessionByIdRequest request, CancellationToken cancellationToken)
        {
            var session = await repo.Sessions
                .Where(x => x.Id == request.Id)
                .Select(x => new GetSessionByIdResponse
                {
                    Id = x.Id,
                    CampaignId = x.CampaignId,
                    CampaignTitle = x.Campaign.Title,
                    Title = x.Title,
                    Summary = x.Summary,
                    HouseKeeping = x.Campaign.Users.Where(y => y.UserId == identityInfo.GetIdentityId() && y.Role == CampaignRoleEnum.GameMaster).Any() ? x.HouseKeeping : null,
                    IsPrivate = x.IsPrivate,
                    ScheduledDate = x.ScheduledDate,
                    DateTimeCreated = x.DateTimeCreated
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (session is null)
                throw new NotFoundException(nameof(Session), request.Id);

            return session;
        }
    }
}
