
using Application.Common.Exceptions;
using Domain.Common.Interfaces;

namespace Persistence.Repositories
{
    public class NoteRepository : JudgedRepository<ManagerContext>, INoteRepository
    {
        public NoteRepository(ManagerContext context, IIdentityInfo info, IEnumerable<IProtected> protection) : base(context, info, protection)
        {
        }

        public IQueryable<TNoteLink> QueryNoteLink<TNoteLink>() where TNoteLink : class, INoteLink
        {
            return Secure<TNoteLink>();
        }

        public IQueryable<INoteLink> QueryNoteLink(NoteHolderEnum noteHolder)
        {
            IQueryable<INoteLink> query = noteHolder switch
            {
                NoteHolderEnum.Campaign => QueryNoteLink<CampaignNote>(),
                NoteHolderEnum.Session => QueryNoteLink<SessionNote>(),
                NoteHolderEnum.Location => QueryNoteLink<LocationNote>(),
                _ => throw new NoteHolderOutOfRangeException(nameof(noteHolder), noteHolder)
            };

            return query;
        }

        public async Task<INoteLink?> GetNoteByLink(Guid Id, NoteHolderEnum noteHolder, CancellationToken cancellationToken)
        {
            return await QueryNoteLink(noteHolder)
                .Include(nl => nl.Note)
                .Where(nl => nl.NoteId == Id)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
