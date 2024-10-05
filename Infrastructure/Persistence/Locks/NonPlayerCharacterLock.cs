
namespace Persistence.Locks
{
    public class NonPlayerCharacterLock(ManagerContext context) : Lock<NonPlayerCharacter>
    {
        public override async Task<bool> HasAccess(NonPlayerCharacter obj, RepositoryOperationEnum operation, int identityId, CancellationToken cancellationToken)
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

            var query = from npc in context.Set<NonPlayerCharacter>()
                        join uc in context.Set<UserCampaign>() on npc.CampaignId equals uc.CampaignId
                        where
                            npc.Id == obj.Id
                            && uc.UserId == identityId
                            && uc.CampaignId == obj.CampaignId
                            && uc.Role == CampaignRoleEnum.GameMaster
                        select npc;

            return await query.AnyAsync(cancellationToken);
        }

        public override IQueryable<NonPlayerCharacter> Secured(int identityId)
        {
            return from npc in context.Set<NonPlayerCharacter>()
                   join uc in context.Set<UserCampaign>() on npc.CampaignId equals uc.CampaignId
                   where
                   uc.UserId == identityId
                   && (
                           uc.Role == CampaignRoleEnum.GameMaster
                           || !npc.IsPrivate
                       )
                   select npc;
        }
    }
}
