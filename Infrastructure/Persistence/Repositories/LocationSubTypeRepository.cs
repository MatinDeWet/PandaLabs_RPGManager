namespace Persistence.Repositories
{
    public class LocationSubTypeRepository : JudgedRepository<ManagerContext>, ILocationSubTypeRepository
    {
        public LocationSubTypeRepository(ManagerContext context, IIdentityInfo info, IEnumerable<IProtected> protection) : base(context, info, protection)
        {
        }

        public IQueryable<LocationSubType> LocationSubTypes =>
            from lst in _context.Set<LocationSubType>()
            select lst;
    }
}
