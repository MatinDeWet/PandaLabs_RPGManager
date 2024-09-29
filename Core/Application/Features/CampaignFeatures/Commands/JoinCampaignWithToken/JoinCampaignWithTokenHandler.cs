namespace Application.Features.CampaignFeatures.Commands.JoinCampaignWithToken
{
    public class JoinCampaignWithTokenHandler(ICampaignRepository campaignRepo, IUserCampaignRepository userRepo, IIdentityInfo identityInfo, IUnitOfWork unitOfWork)
        : ICommandHandler<JoinCampaignWithTokenRequest>
    {
        public async Task<Unit> Handle(JoinCampaignWithTokenRequest request, CancellationToken cancellationToken)
        {
            var campaign = await campaignRepo.CampaignsUnlocked
                .Where(c => c.Token == request.Token)
                .FirstOrDefaultAsync(cancellationToken);

            if (campaign is null)
                throw new NotFoundException(nameof(Campaign), request.Token);

            var identityId = identityInfo.GetIdentityId();

            var alreadyAdded = await userRepo.UserCampaigns
                .Where(x => x.CampaignId == campaign.Id && x.UserId == identityId)
                .AnyAsync(cancellationToken);

            if (alreadyAdded)
                throw new ArgumentException("User already added to Campaign");

            var userCampaign = new UserCampaign
            {
                UserId = identityId,
                CampaignId = campaign.Id,
                Role = CampaignRoleEnum.Player
            };

            await userRepo.InsertAsync(userCampaign, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
