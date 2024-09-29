namespace Persistence.Repositories
{
    public class UserCampaignRepository : JudgedRepository<ManagerContext>, IUserCampaignRepository
    {
        public UserCampaignRepository(ManagerContext context, IIdentityInfo info, IEnumerable<IProtected> protection) : base(context, info, protection)
        {
        }

        public IQueryable<UserCampaign> UserCampaigns =>
            from uc in Secure<UserCampaign>()
            select uc;
    }
}
