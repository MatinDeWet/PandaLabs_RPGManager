using Domain.Common.Interfaces;

namespace Application.Repositories
{
    public interface INoteRepository : IRepository
    {
        IQueryable<INoteLink> QueryNoteLink(NoteHolderEnum noteHolder, Guid? holderId = null);

        Task<INoteLink?> GetNoteByLink(Guid Id, NoteHolderEnum noteHolder, CancellationToken cancellationToken);
    }
}
