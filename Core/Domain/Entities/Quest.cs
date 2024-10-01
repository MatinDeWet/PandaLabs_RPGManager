using Domain.Common.BaseEntities;

namespace Domain.Entities
{
    public class Quest : PrivatibleEntity<Guid>
    {
        public string Title { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public bool IsCompleted { get; set; } = false;

        public Guid CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; } = null!;

        public Guid? FoundInId { get; set; }
        public virtual Location? FoundIn { get; set; }

        public Guid? SessionId { get; set; }
        public virtual Session? Session { get; set; }
    }
}
