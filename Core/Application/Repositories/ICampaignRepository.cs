namespace Application.Repositories
{
    public interface ICampaignRepository : IRepository
    {
        IQueryable<Campaign> Campaigns { get; }

        IQueryable<Campaign> CampaignsUnlocked { get; }
    }
}
