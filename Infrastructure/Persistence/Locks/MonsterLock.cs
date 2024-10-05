namespace Persistence.Locks
{
    public class MonsterLock(ManagerContext context) : Lock<Monster>
    {
        public override async Task<bool> HasAccess(Monster obj, RepositoryOperationEnum operation, int identityId, CancellationToken cancellationToken)
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

            var query = from m in context.Set<Monster>()
                        join uc in context.Set<UserCampaign>() on m.CampaignId equals uc.CampaignId
                        where
                            m.Id == obj.Id
                            && uc.UserId == identityId
                            && uc.Role == CampaignRoleEnum.GameMaster
                        select m;

            return await query.AnyAsync(cancellationToken);
        }

        public override IQueryable<Monster> Secured(int identityId)
        {
            return from m in context.Set<Monster>()
                   join uc in context.Set<UserCampaign>() on m.CampaignId equals uc.CampaignId into ucGroup
                   from uc in ucGroup.DefaultIfEmpty()
                   where
                    uc == null
                    || (
                        uc.UserId == identityId
                        && (
                            uc.Role == CampaignRoleEnum.GameMaster
                            || (m.IsPrivate != null ? !m.IsPrivate.Value : true)
                        )
                    )
                   select m;
        }
    }
}
