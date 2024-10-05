namespace Persistence.Locks
{
    public class SessionLock(ManagerContext context) : Lock<Session>
    {
        public override async Task<bool> HasAccess(Session obj, RepositoryOperationEnum operation, int identityId, CancellationToken cancellationToken)
        {
            if (operation == RepositoryOperationEnum.Insert)
            {
                var insertQuery = from uc in context.Set<UserCampaign>()
                                  where
                                      uc.UserId == identityId
                                      && uc.CampaignId == obj.CampaignId
                                      && uc.Role == CampaignRoleEnum.GameMaster
                                  select uc;

                return await insertQuery.AnyAsync(cancellationToken);
            }

            var query = from s in context.Set<Session>()
                        join uc in context.Set<UserCampaign>() on s.CampaignId equals uc.CampaignId
                        where
                            s.Id == obj.Id
                            && uc.UserId == identityId
                            && uc.CampaignId == obj.CampaignId
                            && uc.Role == CampaignRoleEnum.GameMaster
                        select s;

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
