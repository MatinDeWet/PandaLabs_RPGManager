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
    }
}
