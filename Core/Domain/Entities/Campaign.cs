using Domain.Common.Abstractions;

namespace Domain.Entities
{
    public class Campaign : Entity<Guid>
    {
        public string Title { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public string Token { get; set; } = null!;

        public virtual ICollection<UserCampaign> Users { get; set; } = new List<UserCampaign>();

        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

        public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
    }
}
