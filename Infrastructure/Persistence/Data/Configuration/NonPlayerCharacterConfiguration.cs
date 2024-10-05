namespace Persistence.Data.Configuration
{
    public partial class NonPlayerCharacterConfiguration : IEntityTypeConfiguration<NonPlayerCharacter>
    {
        public void Configure(EntityTypeBuilder<NonPlayerCharacter> entity)
        {
            entity.Property(e => e.CampaignId)
                .HasColumnName("NonPlayerCharacter_CampaignId");

            entity.HasOne(d => d.Campaign)
                .WithMany(p => p!.NonPlayersCharacters)
                .HasForeignKey(d => d.CampaignId)
                .OnDelete(DeleteBehavior.Cascade);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<NonPlayerCharacter> entity);
    }
}
