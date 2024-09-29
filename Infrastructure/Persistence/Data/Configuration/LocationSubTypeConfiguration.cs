namespace Persistence.Data.Configuration
{
    public partial class LocationSubTypeConfiguration : IEntityTypeConfiguration<LocationSubType>
    {
        public void Configure(EntityTypeBuilder<LocationSubType> entity)
        {
            entity.ToTable(nameof(LocationSubType));

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(64);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<LocationSubType> entity);
    }
}
