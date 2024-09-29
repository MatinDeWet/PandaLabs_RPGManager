namespace Application.Repositories
{
    public interface ILocationRepository : IRepository
    {
        IQueryable<Location> Locations { get; }
    }
}
