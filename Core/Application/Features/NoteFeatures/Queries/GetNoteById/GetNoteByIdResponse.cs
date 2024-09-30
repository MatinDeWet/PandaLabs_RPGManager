namespace Application.Features.NoteFeatures.Queries.GetNoteById
{
    public record GetNoteByIdResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        public bool IsPrivate { get; set; }

        public int CreatedById { get; set; }

        public string CreatedByName { get; set; } = null!;

        public DateTime DateTimeCreated { get; set; }
    }
}
