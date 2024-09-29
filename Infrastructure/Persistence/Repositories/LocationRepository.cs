using Domain.Common.Interfaces;
using LinqKit;
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

        public IQueryable<T> QueryLocationLink<T>() where T : class, ILocationLinkEntity
        {
            return Secure<T>().AsExpandable();
        }

        public IQueryable<TLocationLink?> QueryLocationLink<TLocationLink>(
            Expression<Func<TLocationLink, bool>> predicate)
            where TLocationLink : class, ILocationLinkEntity
        {
            return QueryLocationLink<TLocationLink>()
                .Include(nl => nl.Location)
                .Where(predicate);
        }
    }
}
