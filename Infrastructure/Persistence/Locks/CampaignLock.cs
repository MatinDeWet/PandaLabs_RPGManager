namespace Persistence.Locks
{
    public class CampaignLock(ManagerContext context) : Lock<Campaign>
    {
        public override async Task<bool> HasAccess(Campaign obj, RepositoryOperationEnum operation, int identityId, CancellationToken cancellationToken)
        {
            if (operation == RepositoryOperationEnum.Insert)
                return true;

            var query = from c in context.Set<Campaign>()
                        join uc in context.Set<UserCampaign>() on c.Id equals uc.CampaignId
                        where
                            c.Id == obj.Id
                            && uc.UserId == identityId
                            && uc.Role == CampaignRoleEnum.GameMaster
                        select c;

            return await query.AnyAsync(cancellationToken);
        }

        public override IQueryable<Campaign> Secured(int identityId)
        {
            return from c in context.Set<Campaign>()
                   join uc in context.Set<UserCampaign>() on c.Id equals uc.CampaignId
                   where uc.UserId == identityId
                   select c;
        }
    }
}
