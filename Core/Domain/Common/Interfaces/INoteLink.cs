using Domain.Entities;

namespace Domain.Common.Interfaces
{
    public interface INoteLink
    {
        Guid NoteId { get; set; }

        Note Note { get; set; }
    }
}
