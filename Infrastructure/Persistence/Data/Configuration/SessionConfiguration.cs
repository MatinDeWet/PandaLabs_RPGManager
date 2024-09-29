namespace Persistence.Data.Configuration
{
    public partial class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> entity)
        {
            entity.ToTable(nameof(Session));

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(64);

            entity.Property(e => e.Summary)
                .HasMaxLength(16384);

            entity.Property(e => e.HouseKeeping)
                .HasMaxLength(16384);

            entity.HasOne(e => e.Campaign)
                .WithMany(e => e.Sessions)
                .HasForeignKey(e => e.CampaignId)
                .OnDelete(DeleteBehavior.Cascade);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Session> entity);
    }
}
