namespace Application.Features.SessionFeatures.Queries.SearchSessions
{
    public record SearchSessionsResponse
    {
        public Guid Id { get; set; }

        public Guid CampaignId { get; set; }

        public string CampaignTitle { get; set; } = null!;

        public string Title { get; set; } = null!;

        public bool IsPrivate { get; set; }

        public DateOnly? ScheduledDate { get; set; }

        public DateTime DateTimeCreated { get; set; }
    }
}
