using Domain.Common.BaseEntities;

namespace Domain.Entities
{
    public class Note : PrivatibleEntity<Guid>
    {
        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        public virtual ICollection<CampaignNote> Campaigns { get; set; } = new List<CampaignNote>();

        public virtual ICollection<SessionNote> Sessions { get; set; } = new List<SessionNote>();

        public virtual ICollection<LocationNote> Locations { get; set; } = new List<LocationNote>();
    }
}
