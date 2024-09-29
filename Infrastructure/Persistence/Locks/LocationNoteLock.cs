namespace Persistence.Locks
{
    public class LocationNoteLock(ManagerContext context) : Lock<LocationNote>
    {
        public override async Task<bool> HasAccess(LocationNote obj, RepositoryOperationEnum operation, int identityId, CancellationToken cancellationToken)
        {
            if (operation == RepositoryOperationEnum.Insert)
            {
                var insertQuery = from l in context.Set<Location>()
                                  join uc in context.Set<UserCampaign>() on l.CampaignId equals uc.CampaignId
                                  where
                                      l.Id == obj.LocationId
                                      && uc.UserId == identityId
                                  select uc;

                return await insertQuery.AnyAsync(cancellationToken);
            }

            var query = from l in context.Set<Location>()
                        join uc in context.Set<UserCampaign>() on l.CampaignId equals uc.CampaignId
                        where
                            l.Id == obj.LocationId
                            && uc.UserId == identityId
                            && (
                                    obj.Note.CreatedById == identityId
                                    || uc.Role == CampaignRoleEnum.GameMaster
                                )
                        select uc;

            return await query.AnyAsync(cancellationToken);
        }

        public override IQueryable<LocationNote> Secured(int identityId)
        {
            return from ln in context.Set<LocationNote>()
                   join l in context.Set<Location>() on ln.LocationId equals l.Id
                   join uc in context.Set<UserCampaign>() on l.CampaignId equals uc.CampaignId
                   where
                       uc.UserId == identityId
                       && (
                           uc.Role == CampaignRoleEnum.GameMaster
                           ||
                           (
                               !l.IsPrivate
                               && (
                                   !ln.Note.IsPrivate
                                   || (ln.Note.IsPrivate && ln.Note.CreatedById == identityId)
                               )
                           )
                       )
                   select ln;
        }
    }
}
