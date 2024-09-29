namespace Application.Repositories
{
    public interface ISessionRepository : IRepository
    {
        IQueryable<Session> Sessions { get; }
    }
}
