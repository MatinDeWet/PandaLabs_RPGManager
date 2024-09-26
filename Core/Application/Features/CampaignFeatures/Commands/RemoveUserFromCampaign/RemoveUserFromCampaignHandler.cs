using Domain.Enums;

namespace Application.Features.CampaignFeatures.Commands.RemoveUserFromCampaign
{
    public class RemoveUserFromCampaignHandler(ICampaignRepository repo, IUnitOfWork unitOfWork, IIdentityInfo identityInfo)
        : ICommandHandler<RemoveUserFromCampaignRequest>
    {
        public async Task<Unit> Handle(RemoveUserFromCampaignRequest request, CancellationToken cancellationToken)
        {
            var campaign = await repo.Campaigns
                .Include(x => x.Users)
                .Where(x => x.Id == request.CampaignId)
                .FirstOrDefaultAsync(cancellationToken);

            if (campaign is null)
                throw new NotFoundException(nameof(Campaign), request.CampaignId);

            var user = campaign.Users.FirstOrDefault(x => x.UserId == request.UserId);

            if (user is null)
                throw new NotFoundException(nameof(UserCampaign), new { request.CampaignId, request.UserId });

            if (user.UserId == identityInfo.GetIdentityId() && user.Role == CampaignRoleEnum.GameMaster)
                throw new BadRequestException("You cannot remove yourself from the campaign. You are the game master.");

            campaign.Users.Remove(user);

            await repo.UpdateAsync(campaign, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
