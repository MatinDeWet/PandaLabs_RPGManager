using Application.Common.Tools;

namespace Application.Features.LocationFeatures.Queries.Common
{
    public record SearchLocationsResponse
    {
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }
        public string? ParentName { get; set; } = null!;

        public string Title { get; set; } = null!;

        public LocationTypeEnum Type { get; set; }
        public string TypeName => Type.GetDisplayName();

        public int? SubTypeId { get; set; }
        public string? SubTypeName { get; set; } = null!;

        public bool IsPrivate { get; set; }

        public DateTime DateTimeCreated { get; set; }
    }
}
