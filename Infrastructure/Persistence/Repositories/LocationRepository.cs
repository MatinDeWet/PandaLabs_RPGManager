using Application.Common.Exceptions;
using Domain.Common.Interfaces;
using Persistence.Common;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class LocationRepository : JudgedRepository<ManagerContext>, ILocationRepository
    {
        public LocationRepository(ManagerContext context, IIdentityInfo info, IEnumerable<IProtected> protection) : base(context, info, protection)
        {
        }

        public IQueryable<Location> Locations =>
            from l in Secure<Location>()
            select l;

        public IQueryable<ILocationLink> QueryLocationLink(LocationHolderEnum locationHolder, Guid? holderId = null)
        {
            return locationHolder switch
            {
                LocationHolderEnum.Session => BuildQuery<SessionLocation>(holderId, x => x.SessionId),
                _ => throw new LocationHolderOutOfRangeException(nameof(locationHolder), locationHolder)
            };
        }

        private IQueryable<ILocationLink> BuildQuery<TLocationLink>(Guid? holderId, Expression<Func<TLocationLink, Guid>> holderIdSelector)
            where TLocationLink : class, ILocationLink
        {
            var query = Secure<TLocationLink>();

            if (holderId.HasValue)
                query = query.Where(holderIdSelector.Compose(id => id == holderId.Value));

            return query;
        }
    }
}
