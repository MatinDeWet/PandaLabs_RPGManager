using Domain.Common.Abstractions;
using Domain.Common.Interfaces;

namespace Domain.Entities
{
    public class Campaign : Entity<Guid>, INoteHolder
    {
        public string Title { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public string Token { get; set; } = null!;

        public virtual ICollection<UserCampaign> Users { get; set; } = new List<UserCampaign>();

        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

        public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

        public virtual ICollection<CampaignNote> Notes { get; set; } = new List<CampaignNote>();

        public virtual ICollection<Quest> Quests { get; set; } = new List<Quest>();
    }
}
