using Domain.Common.Interfaces;
using System.Linq.Expressions;

namespace Application.Repositories
{
    public interface ILocationRepository : IRepository
    {
        IQueryable<Location> Locations { get; }

        IQueryable<T> QueryLocationLink<T>() where T : class, ILocationLinkEntity;

        IQueryable<TLocationLink?> QueryLocationLink<TLocationLink>(
            Expression<Func<TLocationLink, bool>> predicate)
            where TLocationLink : class, ILocationLinkEntity;
    }
}
