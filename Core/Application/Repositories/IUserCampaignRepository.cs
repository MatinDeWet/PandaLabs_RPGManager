namespace Application.Repositories
{
    public interface IUserCampaignRepository : IRepository
    {
        IQueryable<UserCampaign> UserCampaigns { get; }
    }
}
