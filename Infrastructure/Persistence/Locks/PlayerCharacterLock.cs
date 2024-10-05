
namespace Persistence.Locks
{
    public class PlayerCharacterLock(ManagerContext context) : Lock<PlayerCharacter>
    {
        public override async Task<bool> HasAccess(PlayerCharacter obj, RepositoryOperationEnum operation, int identityId, CancellationToken cancellationToken)
        {
            if (operation == RepositoryOperationEnum.Insert)
                return true;

            var query = from pc in context.Set<PlayerCharacter>()
                        join uc in context.Set<UserCampaign>() on pc.CampaignId equals uc.CampaignId into ucgroup
                        from uc in ucgroup.DefaultIfEmpty()
                        where
                        (
                            pc.Id == obj.Id
                            && pc.CreatedById == identityId
                            && uc != null
                        ) ||
                        (
                            pc.Id == obj.Id
                            && uc.UserId == identityId
                            && uc.CampaignId == obj.CampaignId
                            && uc.Role == CampaignRoleEnum.GameMaster
                        )
                        select pc;

            return await query.AnyAsync(cancellationToken);
        }

        public override IQueryable<PlayerCharacter> Secured(int identityId)
        {
            return from pc in context.Set<PlayerCharacter>()
                   join uc in context.Set<UserCampaign>() on pc.CampaignId equals uc.CampaignId into ucgroup
                   from uc in ucgroup.DefaultIfEmpty()
                   where
                    (
                        pc.CreatedById == identityId
                        && uc != null
                    )
                    || uc.UserId == identityId
                   select pc;
        }
    }
}
