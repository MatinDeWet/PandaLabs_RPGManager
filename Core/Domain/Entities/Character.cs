namespace Domain.Entities
{
    public abstract class Character : Entity<Guid>
    {
        public CharacterTypeEnum CharacterType { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int HitPoints { get; set; }

        public int ArmorClass { get; set; }

        public AlignmentEnum Alignment { get; set; }
    }
}
