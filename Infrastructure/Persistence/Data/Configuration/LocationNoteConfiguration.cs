namespace Persistence.Data.Configuration
{
    public partial class LocationNoteConfiguration : IEntityTypeConfiguration<LocationNote>
    {
        public void Configure(EntityTypeBuilder<LocationNote> entity)
        {
            entity.ToTable(nameof(LocationNote));

            entity.HasKey(e => new { e.LocationId, e.NoteId });

            entity.HasOne(e => e.Location)
                .WithMany(e => e.Notes)
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Note)
                .WithMany(e => e.Locations)
                .HasForeignKey(e => e.NoteId)
                .OnDelete(DeleteBehavior.Cascade);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<LocationNote> entity);
    }
}
