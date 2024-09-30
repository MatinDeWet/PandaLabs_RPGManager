using Application.Common.Exceptions;
using Domain.Common.Interfaces;
using Persistence.Common;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class NoteRepository : JudgedRepository<ManagerContext>, INoteRepository
    {
        public NoteRepository(ManagerContext context, IIdentityInfo info, IEnumerable<IProtected> protection) : base(context, info, protection)
        {
        }

        public IQueryable<INoteLink> QueryNoteLink(NoteHolderEnum noteHolder, Guid? holderId = null)
        {
            return noteHolder switch
            {
                NoteHolderEnum.Campaign => BuildQuery<CampaignNote>(holderId, x => x.CampaignId),
                NoteHolderEnum.Session => BuildQuery<SessionNote>(holderId, x => x.SessionId),
                NoteHolderEnum.Location => BuildQuery<LocationNote>(holderId, x => x.LocationId),
                _ => throw new NoteHolderOutOfRangeException(nameof(noteHolder), noteHolder)
            };
        }

        public async Task<INoteLink?> GetNoteByLink(Guid Id, NoteHolderEnum noteHolder, CancellationToken cancellationToken)
        {
            return await QueryNoteLink(noteHolder)
                .Include(nl => nl.Note)
                .Where(nl => nl.NoteId == Id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        private IQueryable<INoteLink> BuildQuery<TNoteLink>(Guid? holderId, Expression<Func<TNoteLink, Guid>> holderIdSelector)
            where TNoteLink : class, INoteLink
        {
            var query = Secure<TNoteLink>();

            if (holderId.HasValue)
                query = query.Where(holderIdSelector.Compose(id => id == holderId.Value));

            return query;
        }
    }
}
