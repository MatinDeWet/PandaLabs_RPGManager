namespace Application.Features.SessionFeatures.Queries.GetSessionById
{
    public record GetSessionByIdResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Summary { get; set; }

        public string? HouseKeeping { get; set; }

        public bool IsPrivate { get; set; }

        public DateOnly? ScheduledDate { get; set; }

        public DateTime DateTimeCreated { get; set; }
    }
}
