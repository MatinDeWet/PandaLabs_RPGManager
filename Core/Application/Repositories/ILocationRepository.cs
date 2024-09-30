using Domain.Common.Interfaces;

namespace Application.Repositories
{
    public interface ILocationRepository : IRepository
    {
        IQueryable<Location> Locations { get; }

        IQueryable<ILocationLink> QueryLocationLink(LocationHolderEnum locationHolder, Guid? holderId = null);
    }
}
