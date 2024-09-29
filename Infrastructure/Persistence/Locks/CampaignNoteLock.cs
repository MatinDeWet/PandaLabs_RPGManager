namespace Persistence.Locks
{
    public class CampaignNoteLock(ManagerContext context) : Lock<CampaignNote>
    {
        public override async Task<bool> HasAccess(CampaignNote obj, RepositoryOperationEnum operation, int identityId, CancellationToken cancellationToken)
        {
            if (operation == RepositoryOperationEnum.Insert)
            {
                var insertQuery = from uc in context.Set<UserCampaign>()
                                  where
                                      uc.CampaignId == obj.CampaignId
                                      && uc.UserId == identityId
                                  select uc;

                return await insertQuery.AnyAsync(cancellationToken);
            }

            var query = from uc in context.Set<UserCampaign>()
                        where
                            uc.CampaignId == obj.CampaignId
                            && uc.UserId == identityId
                            && (
                                    obj.Note.CreatedById == identityId
                                    || uc.Role == CampaignRoleEnum.GameMaster
                                )
                        select uc;

            return await query.AnyAsync(cancellationToken);
        }

        public override IQueryable<CampaignNote> Secured(int identityId)
        {
            return from cn in context.Set<CampaignNote>()
                   join uc in context.Set<UserCampaign>() on cn.CampaignId equals uc.CampaignId
                   where
                   uc.UserId == identityId
                   && (
                           uc.Role == CampaignRoleEnum.GameMaster
                           || !cn.Note.IsPrivate
                           || (cn.Note.IsPrivate && cn.Note.CreatedById == identityId)
                       )
                   select cn;
        }
    }
}
