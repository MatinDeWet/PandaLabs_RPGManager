namespace Application.Features.CampaignFeatures.Queries.GetCampaignUsers
{
    public class GetCampaignUsersHandler(ICampaignRepository repo)
        : IQueryHandler<GetCampaignUsersRequest, List<GetCampaignUsersResponse>>
    {
        public async Task<List<GetCampaignUsersResponse>> Handle(GetCampaignUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await repo.Campaigns
                .Where(x => x.Id == request.Id)
                .SelectMany(x => x.Users)
                .Select(x => new GetCampaignUsersResponse
                {
                    Id = x.UserId,
                    Name = x.User.UserName!,
                    RoleId = x.Role
                })
                .ToListAsync(cancellationToken);

            return users;
        }
    }
}
