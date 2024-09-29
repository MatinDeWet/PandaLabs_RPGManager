namespace Persistence.Locks
{
    public class SessionNoteLock(ManagerContext context) : Lock<SessionNote>
    {
        public override async Task<bool> HasAccess(SessionNote obj, RepositoryOperationEnum operation, int identityId, CancellationToken cancellationToken)
        {
            if (operation == RepositoryOperationEnum.Insert)
            {
                var insertQuery = from s in context.Set<Session>()
                                  join uc in context.Set<UserCampaign>() on s.CampaignId equals uc.CampaignId
                                  where
                                      s.Id == obj.SessionId
                                      && uc.UserId == identityId
                                  select s;

                return await insertQuery.AnyAsync(cancellationToken);
            }

            var query = from s in context.Set<Session>()
                        join uc in context.Set<UserCampaign>() on s.CampaignId equals uc.CampaignId
                        where
                            s.Id == obj.SessionId
                            && uc.UserId == identityId
                            && (
                                    obj.Note.CreatedById == identityId
                                    || uc.Role == CampaignRoleEnum.GameMaster
                                )
                        select s;

            return await query.AnyAsync(cancellationToken);
        }

        public override IQueryable<SessionNote> Secured(int identityId)
        {
            return from sn in context.Set<SessionNote>()
                   join s in context.Set<Session>() on sn.SessionId equals s.Id
                   join uc in context.Set<UserCampaign>() on s.CampaignId equals uc.CampaignId
                   where
                    uc.UserId == identityId
                    && (
                            uc.Role == CampaignRoleEnum.GameMaster
                            || !sn.Note.IsPrivate
                            || (sn.Note.IsPrivate && sn.Note.CreatedById == identityId)
                        )
                   select sn;
        }
    }
}
