using Domain.Entities;

namespace Domain.Common.Interfaces
{
    public interface ILocationLink
    {
        Guid LocationId { get; set; }

        Location Location { get; }
    }
}
