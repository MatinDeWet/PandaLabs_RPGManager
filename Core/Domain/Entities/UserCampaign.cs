namespace Domain.Entities
{
    public class UserCampaign
    {
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;

        public Guid CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; } = null!;

        public CampaignRoleEnum Role { get; set; }
    }
}
