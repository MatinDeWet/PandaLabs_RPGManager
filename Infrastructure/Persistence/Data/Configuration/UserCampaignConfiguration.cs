namespace Persistence.Data.Configuration
{
    public partial class UserCampaignConfiguration : IEntityTypeConfiguration<UserCampaign>
    {
        public void Configure(EntityTypeBuilder<UserCampaign> entity)
        {
            entity.ToTable(nameof(UserCampaign));

            entity.HasKey(e => new { e.UserId, e.CampaignId });

            entity.HasIndex(e => e.CampaignId);
            entity.HasIndex(e => e.UserId);

            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Campaign)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.CampaignId)
                .OnDelete(DeleteBehavior.Cascade);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<UserCampaign> entity);
    }
}
