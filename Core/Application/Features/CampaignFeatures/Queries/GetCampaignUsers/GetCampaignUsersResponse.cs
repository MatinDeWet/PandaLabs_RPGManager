using Application.Common.Tools;
using Domain.Enums;

namespace Application.Features.CampaignFeatures.Queries.GetCampaignUsers
{
    public class GetCampaignUsersResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public CampaignRoleEnum RoleId { get; set; }
        public string RoleName => RoleId.GetDisplayName(true);
    }
}
