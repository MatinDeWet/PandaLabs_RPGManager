using Domain.Common.Interfaces;

namespace Domain.Entities
{
    public class SessionNote : INoteLink
    {
        public SessionNote()
        {
        }

        public SessionNote(Guid sessionId, Note note)
        {
            SessionId = sessionId;
            Note = note;
        }

        public Guid SessionId { get; set; }
        public virtual Session Session { get; set; } = null!;

        public Guid NoteId { get; set; }
        public virtual Note Note { get; set; } = null!;
    }
}
