namespace Persistence.Repositories
{
    public class CharacterRepository : JudgedRepository<ManagerContext>, ICharacterRepository
    {
        public CharacterRepository(ManagerContext context, IIdentityInfo info, IEnumerable<IProtected> protection) : base(context, info, protection)
        {
        }

        public IQueryable<Monster> Monsters =>
            from m in Secure<Monster>()
            select m;

        public IQueryable<NonPlayerCharacter> NonPlayerCharacters =>
            from npc in Secure<NonPlayerCharacter>()
            select npc;

        public IQueryable<PlayerCharacter> PlayerCharacters =>
            from pc in Secure<PlayerCharacter>()
            select pc;
    }
}
