using Domain.Common.Interfaces;

namespace Domain.Entities
{
    public class LocationNote : INoteLink
    {
        public LocationNote()
        {
        }

        public LocationNote(Guid locationId, Note note)
        {
            LocationId = locationId;
            Note = note;
        }

        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; } = null!;

        public Guid NoteId { get; set; }
        public virtual Note Note { get; set; } = null!;
    }
}
