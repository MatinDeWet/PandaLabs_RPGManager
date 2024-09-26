namespace Persistence.Locks
{
    public class SessionLock(ManagerContext context) : Lock<Session>
    {
        public override async Task<bool> HasAccess(Session obj, RepositoryOperationEnum operation, int identityId, CancellationToken cancellationToken)
        {
            var query = from uc in context.Set<UserCampaign>()
                        where
                            uc.UserId == identityId
                            && uc.CampaignId == obj.CampaignId
                            && uc.Role == CampaignRoleEnum.GameMaster
                        select uc;

            return await query.AnyAsync(cancellationToken);
        }

        public override IQueryable<Session> Secured(int identityId)
        {
            return from s in context.Set<Session>()
                   join uc in context.Set<UserCampaign>() on s.CampaignId equals uc.CampaignId
                   where
                   uc.UserId == identityId
                   && (
                           uc.Role == CampaignRoleEnum.GameMaster
                           || !s.IsPrivate
                       )
                   select s;
        }
    }
}
