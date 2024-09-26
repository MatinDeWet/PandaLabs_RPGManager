namespace Application.Features.CampaignFeatures.Commands.LeaveCampaign
{
    public class LeaveCampaignHandler(IUserCampaignRepository repo, IUnitOfWork unitOfWork, IIdentityInfo identityInfo)
        : ICommandHandler<LeaveCampaignRequest>
    {
        public async Task<Unit> Handle(LeaveCampaignRequest request, CancellationToken cancellationToken)
        {
            var identityId = identityInfo.GetIdentityId();

            var userCampaign = await repo.UserCampaigns
                .Where(x => x.CampaignId == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (userCampaign is null)
                throw new NotFoundException(nameof(UserCampaign), new { request.Id, UserId = identityId });

            if (userCampaign.UserId == identityId && userCampaign.Role == CampaignRoleEnum.GameMaster)
                throw new BadRequestException("You cannot leave the campaign. You are the game master.");

            await repo.DeleteAsync(userCampaign, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
