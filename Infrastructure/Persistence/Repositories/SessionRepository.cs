namespace Persistence.Repositories
{
    public class SessionRepository : JudgedRepository<ManagerContext>, ISessionRepository
    {
        public SessionRepository(ManagerContext context, IIdentityInfo info, IEnumerable<IProtected> protection) : base(context, info, protection)
        {
        }

        public IQueryable<Session> Sessions =>
            from s in Secure<Session>()
            select s;
    }
}
