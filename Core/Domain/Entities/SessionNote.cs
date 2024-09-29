using Domain.Common.Interfaces;

namespace Domain.Entities
{
    public class SessionNote : INoteLink
    {
        public Guid SessionId { get; set; }
        public virtual Session Session { get; set; } = null!;

        public Guid NoteId { get; set; }
        public virtual Note Note { get; set; } = null!;
    }
}
