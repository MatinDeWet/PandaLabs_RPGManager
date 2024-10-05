namespace Persistence.Data.Configuration
{
    public partial class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> entity)
        {
            entity.ToTable(nameof(Character));

            entity.HasKey(e => e.Id);

            entity.HasDiscriminator(e => e.CharacterType)
                .HasValue<PlayerCharacter>(CharacterTypeEnum.PlayerCharacter)
                .HasValue<Monster>(CharacterTypeEnum.Monster)
                .HasValue<NonPlayerCharacter>(CharacterTypeEnum.NonPlayerCharacter);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(64);

            entity.Property(e => e.Description)
                .HasMaxLength(32768);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Character> entity);
    }
}
