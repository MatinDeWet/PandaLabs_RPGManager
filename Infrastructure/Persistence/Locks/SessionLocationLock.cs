namespace Persistence.Locks
{
    public class SessionLocationLock(ManagerContext context) : Lock<SessionLocation>
    {
        public override async Task<bool> HasAccess(SessionLocation obj, RepositoryOperationEnum operation, int identityId, CancellationToken cancellationToken)
        {
            var query = from s in context.Set<Session>()
                        join uc in context.Set<UserCampaign>() on s.CampaignId equals uc.CampaignId
                        where
                            uc.UserId == identityId
                            && s.Id == obj.SessionId
                        select uc;

            return await query.AnyAsync(cancellationToken);
        }

        public override IQueryable<SessionLocation> Secured(int identityId)
        {
            return from sl in context.Set<SessionLocation>()
                   join s in context.Set<Session>() on sl.SessionId equals s.Id
                   join uc in context.Set<UserCampaign>() on s.CampaignId equals uc.CampaignId
                   join l in context.Set<Location>() on sl.LocationId equals l.Id
                   where
                       uc.UserId == identityId
                       && (
                           uc.Role == CampaignRoleEnum.GameMaster
                           || !l.IsPrivate
                       )
                   select sl;
        }
    }
}
