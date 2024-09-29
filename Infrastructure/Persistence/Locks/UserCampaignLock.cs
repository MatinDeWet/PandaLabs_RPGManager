namespace Persistence.Locks
{
    public class UserCampaignLock(ManagerContext context) : Lock<UserCampaign>
    {
        public override async Task<bool> HasAccess(UserCampaign obj, RepositoryOperationEnum operation, int identityId, CancellationToken cancellationToken)
        {
            if (operation == RepositoryOperationEnum.Insert)
                return true;

            var query = from uc in context.Set<UserCampaign>()
                        where uc.UserId == identityId
                        select uc;

            return await query.AnyAsync(cancellationToken);
        }

        public override IQueryable<UserCampaign> Secured(int identityId)
        {
            return from pc in context.Set<UserCampaign>()
                   where pc.UserId == identityId
                   select pc;
        }
    }
}
