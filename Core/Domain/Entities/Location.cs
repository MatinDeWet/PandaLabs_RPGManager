using Domain.Common.BaseEntities;
using Domain.Common.Interfaces;
using Domain.Enums;

namespace Domain.Entities
{
    public class Location : PrivatibleEntity<Guid>, INoteHolder
    {
        public Guid CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; } = null!;

        public Guid? ParentId { get; set; }
        public virtual Location? Parent { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public LocationTypeEnum Type { get; set; }

        public int? SubTypeId { get; set; }
        public virtual LocationSubType? SubType { get; set; } = null!;

        public virtual ICollection<Location> Children { get; set; } = new List<Location>();

        public virtual ICollection<SessionLocation> SessionLocations { get; set; } = new List<SessionLocation>();

        public virtual ICollection<LocationNote> Notes { get; set; } = new List<LocationNote>();

        public virtual ICollection<Quest> Quests { get; set; } = new List<Quest>();
    }
}
