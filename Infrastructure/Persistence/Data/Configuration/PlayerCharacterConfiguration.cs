namespace Persistence.Data.Configuration
{
    public partial class PlayerCharacterConfiguration : IEntityTypeConfiguration<PlayerCharacter>
    {
        public void Configure(EntityTypeBuilder<PlayerCharacter> entity)
        {
            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<PlayerCharacter> entity);
    }
}
