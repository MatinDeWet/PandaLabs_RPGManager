namespace Persistence.Repositories
{
    public class CampaignRepository : JudgedRepository<ManagerContext>, ICampaignRepository
    {
        public CampaignRepository(ManagerContext context, IIdentityInfo info, IEnumerable<IProtected> protection) : base(context, info, protection)
        {
        }

        public IQueryable<Campaign> Campaigns =>
            from c in Secure<Campaign>()
            select c;

        public IQueryable<Campaign> CampaignsUnlocked =>
            from c in _context.Set<Campaign>()
            select c;

        public void UnlockedUpdate(Campaign obj)
        {
            _context.Update(obj);
        }
    }
}
