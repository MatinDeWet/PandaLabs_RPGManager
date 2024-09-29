using Domain.Common.Interfaces;

namespace Domain.Entities
{
    public class SessionLocation : ILocationLink
    {
        public SessionLocation()
        {
        }

        public SessionLocation(Guid sessionId, Guid locationId)
        {
            SessionId = sessionId;
            LocationId = locationId;
        }

        public Guid SessionId { get; set; }
        public virtual Session Session { get; set; } = null!;

        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; } = null!;
    }
}
