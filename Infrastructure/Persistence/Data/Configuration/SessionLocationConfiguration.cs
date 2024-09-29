namespace Persistence.Data.Configuration
{
    public partial class SessionLocationConfiguration : IEntityTypeConfiguration<SessionLocation>
    {
        public void Configure(EntityTypeBuilder<SessionLocation> entity)
        {
            entity.ToTable(nameof(SessionLocation));

            entity.HasKey(e => new { e.SessionId, e.LocationId });

            entity.HasOne(e => e.Session)
                .WithMany(e => e.SessionLocations)
                .HasForeignKey(e => e.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Location)
                .WithMany(e => e.SessionLocations)
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<SessionLocation> entity);
    }
}
