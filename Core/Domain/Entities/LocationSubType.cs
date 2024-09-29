using Domain.Enums;

namespace Domain.Entities
{
    public class LocationSubType
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public LocationTypeEnum Group { get; set; }

        public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
    }
}
