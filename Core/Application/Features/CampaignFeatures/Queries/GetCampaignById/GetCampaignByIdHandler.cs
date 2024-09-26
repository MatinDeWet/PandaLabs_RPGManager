using Domain.Enums;

namespace Application.Features.CampaignFeatures.Queries.GetCampaignById
{
    public class GetCampaignByIdHandler(ICampaignRepository repo, IIdentityInfo identityInfo)
        : IQueryHandler<GetCampaignByIdRequest, GetCampaignByIdResponse>
    {
        public async Task<GetCampaignByIdResponse> Handle(GetCampaignByIdRequest request, CancellationToken cancellationToken)
        {
            var campaign = await repo.Campaigns
                .Where(x => x.Id == request.Id)
                .Select(x => new GetCampaignByIdResponse
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    DateTimeCreated = x.DateTimeCreated,
                    RoleId = x.Users.Where(y => y.UserId == identityInfo.GetIdentityId()).Select(y => y.Role).First(),
                    GameMasterName = x.Users.Where(y => y.Role == CampaignRoleEnum.GameMaster).Select(y => y.User.UserName!).First(),
                    Token = x.Users.Any(y => y.UserId == identityInfo.GetIdentityId() && y.Role == CampaignRoleEnum.GameMaster) ? x.Token : null!
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (campaign is null)
                throw new NotFoundException(nameof(Campaign), request.Id);

            return campaign;
        }
    }
}
