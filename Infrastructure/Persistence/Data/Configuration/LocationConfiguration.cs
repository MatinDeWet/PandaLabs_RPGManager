namespace Persistence.Data.Configuration
{
    public partial class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> entity)
        {
            entity.ToTable(nameof(Location));

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(64);

            entity.Property(e => e.Description)
                .HasMaxLength(16384);

            entity.HasOne(e => e.Campaign)
                .WithMany(e => e.Locations)
                .HasForeignKey(e => e.CampaignId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Parent)
              .WithMany(e => e.Children)
              .HasForeignKey(e => e.ParentId)
              .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(e => e.SubType)
                .WithMany(e => e.Locations)
                .HasForeignKey(e => e.SubTypeId)
                .OnDelete(DeleteBehavior.SetNull);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Location> entity);
    }
}
