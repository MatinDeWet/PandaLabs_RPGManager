namespace Application.Repositories
{
    public interface ILocationSubTypeRepository : IRepository
    {
        IQueryable<LocationSubType> LocationSubTypes { get; }
    }
}
