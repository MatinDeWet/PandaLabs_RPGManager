namespace Application.Features.SessionFeatures.Queries.SearchSessions
{
    public record SearchSessionsResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public bool IsPrivate { get; set; }

        public DateOnly? ScheduledDate { get; set; }

        public DateTime DateTimeCreated { get; set; }
    }
}
