namespace Persistence.Data.Configuration
{
    public partial class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> entity)
        {
            entity.ToTable(nameof(Campaign));

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(64);

            entity.Property(e => e.Description)
                .HasMaxLength(16384);

            entity.Property(e => e.Token)
                .IsRequired()
                .HasMaxLength(32);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Campaign> entity);
    }
}
