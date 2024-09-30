namespace Persistence.Data.Configuration
{
    public partial class SessionNoteConfiguration : IEntityTypeConfiguration<SessionNote>
    {
        public void Configure(EntityTypeBuilder<SessionNote> entity)
        {
            entity.ToTable(nameof(SessionNote));

            entity.HasKey(e => new { e.SessionId, e.NoteId });

            entity.HasOne(e => e.Session)
                .WithMany(e => e.Notes)
                .HasForeignKey(e => e.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Note)
                .WithMany(e => e.Sessions)
                .HasForeignKey(e => e.NoteId)
                .OnDelete(DeleteBehavior.Cascade);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<SessionNote> entity);
    }
}
