namespace Application.Repositories
{
    public interface ICharacterRepository : IRepository
    {
        IQueryable<Monster> Monsters { get; }

        IQueryable<NonPlayerCharacter> NonPlayerCharacters { get; }

        IQueryable<PlayerCharacter> PlayerCharacters { get; }
    }
}
