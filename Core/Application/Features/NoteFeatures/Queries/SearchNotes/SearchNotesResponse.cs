namespace Application.Features.NoteFeatures.Queries.SearchNotes
{
    public record SearchNotesResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public bool IsPrivate { get; set; }

        public int CreatedById { get; set; }

        public string CreatedByName { get; set; } = null!;

        public DateTime DateTimeCreated { get; set; }
    }
}
