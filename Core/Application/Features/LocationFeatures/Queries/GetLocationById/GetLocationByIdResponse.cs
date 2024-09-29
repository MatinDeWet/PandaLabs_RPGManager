using Application.Common.Tools;

namespace Application.Features.LocationFeatures.Queries.GetLocationById
{
    public record GetLocationByIdResponse
    {
        public Guid Id { get; set; }

        public Guid CampaignId { get; set; }
        public string CampaignName { get; set; } = null!;

        public Guid? ParentId { get; set; }
        public string? ParentName { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public LocationTypeEnum Type { get; set; }
        public string TypeName => Type.GetDisplayName();

        public int? SubTypeId { get; set; }
        public string? SubTypeName { get; set; } = null!;

        public bool IsPrivate { get; set; }

        public DateTime DateTimeCreated { get; set; }
    }
}
