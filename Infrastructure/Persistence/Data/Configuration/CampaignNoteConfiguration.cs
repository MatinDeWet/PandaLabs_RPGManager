namespace Persistence.Data.Configuration
{
    public partial class CampaignNoteConfiguration : IEntityTypeConfiguration<CampaignNote>
    {
        public void Configure(EntityTypeBuilder<CampaignNote> entity)
        {
            entity.ToTable(nameof(CampaignNote));

            entity.HasKey(e => new { e.CampaignId, e.NoteId });

            entity.HasOne(e => e.Campaign)
                .WithMany(e => e.Notes)
                .HasForeignKey(e => e.CampaignId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Note)
                .WithMany(e => e.Campaigns)
                .HasForeignKey(e => e.NoteId)
                .OnDelete(DeleteBehavior.Cascade);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<CampaignNote> entity);
    }
}
