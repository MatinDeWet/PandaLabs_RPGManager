using Domain.Common.Interfaces;

namespace Domain.Entities
{
    public class LocationNote : INoteLink
    {
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; } = null!;

        public Guid NoteId { get; set; }
        public virtual Note Note { get; set; } = null!;
    }
}
