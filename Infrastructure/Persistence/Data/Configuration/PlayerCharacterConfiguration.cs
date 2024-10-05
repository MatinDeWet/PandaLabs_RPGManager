namespace Persistence.Data.Configuration
{
    public partial class PlayerCharacterConfiguration : IEntityTypeConfiguration<PlayerCharacter>
    {
        public void Configure(EntityTypeBuilder<PlayerCharacter> entity)
        {
            entity.Property(e => e.CampaignId)
                .HasColumnName("PlayerCharacter_CampaignId");

            entity.HasOne(d => d.Campaign)
                .WithMany(p => p!.PlayerCharacters)
                .HasForeignKey(d => d.CampaignId)
                .OnDelete(DeleteBehavior.SetNull);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<PlayerCharacter> entity);
    }
}
