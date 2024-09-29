using Domain.Common.Interfaces;

namespace Application.Repositories
{
    public interface INoteRepository : IRepository
    {
        IQueryable<TNoteLink> QueryNoteLink<TNoteLink>() where TNoteLink : class, INoteLink;

        IQueryable<INoteLink> QueryNoteLink(NoteHolderEnum noteHolder);

        Task<INoteLink?> GetNoteByLink(Guid Id, NoteHolderEnum noteHolder, CancellationToken cancellationToken);
    }
}
