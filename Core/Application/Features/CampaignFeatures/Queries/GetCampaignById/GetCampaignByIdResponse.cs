using Application.Common.Tools;

namespace Application.Features.CampaignFeatures.Queries.GetCampaignById
{
    public class GetCampaignByIdResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string Token { get; set; } = null!;

        public DateTime DateTimeCreated { get; set; }

        public CampaignRoleEnum RoleId { get; set; }
        public string Rolename => RoleId.GetDisplayName(true);

        public string GameMasterName { get; set; } = null!;
    }
}
