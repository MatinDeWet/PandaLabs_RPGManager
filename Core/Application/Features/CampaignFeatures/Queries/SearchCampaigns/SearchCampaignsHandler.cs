using Application.QueryBuilders;
using Pagination;
using Pagination.Models;

namespace Application.Features.CampaignFeatures.Queries.SearchCampaigns
{
    public class SearchCampaignsHandler(ICampaignRepository repo, IIdentityInfo identityInfo)
            : IQueryHandler<SearchCampaignsRequest, PageableResponse<SearchCampaignsResponse>>
    {
        public async Task<PageableResponse<SearchCampaignsResponse>> Handle(SearchCampaignsRequest request, CancellationToken cancellationToken)
        {
            var userId = identityInfo.GetIdentityId();

            var campaigns = await repo.Campaigns
                .ApplyFilters(request, userId)
                .Select(x => new SearchCampaignsResponse
                {
                    Id = x.Id,
                    Title = x.Title,
                    DateTimeCreated = x.DateTimeCreated,
                    UsersCount = x.Users.Count(),
                    RoleId = x.Users.Where(y => y.UserId == userId).Select(y => y.Role).First(),
                    GameMasterName = x.Users.Where(y => y.Role == CampaignRoleEnum.GameMaster).Select(y => y.User.UserName!).First(),
                })
                .ToPageableListAsync(request, cancellationToken);

            return campaigns;
        }
    }
}
