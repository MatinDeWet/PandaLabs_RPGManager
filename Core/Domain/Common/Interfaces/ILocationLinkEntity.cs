using Domain.Entities;

namespace Domain.Common.Interfaces
{
    public interface ILocationLinkEntity
    {
        Guid LocationId { get; set; }

        Location Location { get; }
    }
}
