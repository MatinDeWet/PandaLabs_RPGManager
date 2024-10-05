namespace Persistence.Data.Configuration
{
    public partial class NonPlayerCharacterConfiguration : IEntityTypeConfiguration<NonPlayerCharacter>
    {
        public void Configure(EntityTypeBuilder<NonPlayerCharacter> entity)
        {
            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<NonPlayerCharacter> entity);
    }
}
