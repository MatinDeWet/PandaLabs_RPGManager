namespace Persistence.Data.Configuration
{
    public partial class MonsterConfiguration : IEntityTypeConfiguration<Monster>
    {
        public void Configure(EntityTypeBuilder<Monster> entity)
        {
            entity.Property(e => e.CampaignId)
                .HasColumnName("Monster_CampaignId");

            entity.HasOne(d => d.Campaign)
                .WithMany(p => p!.Monsters)
                .HasForeignKey(d => d.CampaignId)
                .OnDelete(DeleteBehavior.Cascade);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Monster> entity);
    }
}
