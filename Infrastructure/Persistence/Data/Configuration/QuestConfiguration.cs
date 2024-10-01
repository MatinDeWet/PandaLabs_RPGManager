namespace Persistence.Data.Configuration
{
    public partial class QuestConfiguration : IEntityTypeConfiguration<Quest>
    {
        public void Configure(EntityTypeBuilder<Quest> entity)
        {
            entity.ToTable(nameof(Quest));

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(64);

            entity.Property(e => e.Description)
                .HasMaxLength(16384);

            entity.HasOne(e => e.Campaign)
                .WithMany(e => e.Quests)
                .HasForeignKey(e => e.CampaignId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.FoundIn)
                .WithMany(e => e.Quests)
                .HasForeignKey(e => e.FoundInId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(e => e.Session)
                .WithMany(e => e.Quests)
                .HasForeignKey(e => e.SessionId)
                .OnDelete(DeleteBehavior.SetNull);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Quest> entity);
    }
}
