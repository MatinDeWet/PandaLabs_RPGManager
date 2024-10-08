﻿namespace Persistence.Locks
{
    public class LocationLock(ManagerContext context) : Lock<Location>
    {
        public override async Task<bool> HasAccess(Location obj, RepositoryOperationEnum operation, int identityId, CancellationToken cancellationToken)
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

            var query = from l in context.Set<Location>()
                        join uc in context.Set<UserCampaign>() on l.CampaignId equals uc.CampaignId
                        where
                            l.Id == obj.Id
                            && uc.UserId == identityId
                            && uc.CampaignId == obj.CampaignId
                            && uc.Role == CampaignRoleEnum.GameMaster
                        select l;

            return await query.AnyAsync(cancellationToken);
        }

        public override IQueryable<Location> Secured(int identityId)
        {
            return from l in context.Set<Location>()
                   join uc in context.Set<UserCampaign>() on l.CampaignId equals uc.CampaignId
                   where
                   uc.UserId == identityId
                   && (
                           uc.Role == CampaignRoleEnum.GameMaster
                           || !l.IsPrivate
                       )
                   select l;
        }
    }
}
