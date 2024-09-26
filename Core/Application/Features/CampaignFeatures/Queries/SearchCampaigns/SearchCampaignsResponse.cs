using Application.Common.Tools;
using Domain.Enums;

namespace Application.Features.CampaignFeatures.Queries.SearchCampaigns
{
    public class SearchCampaignsResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public DateTime DateTimeCreated { get; set; }

        public int UsersCount { get; set; }

        public CampaignRoleEnum RoleId { get; set; }
        public string RoleName => RoleId.GetDisplayName(true);

        public string GameMasterName { get; set; } = null!;
    }
}
