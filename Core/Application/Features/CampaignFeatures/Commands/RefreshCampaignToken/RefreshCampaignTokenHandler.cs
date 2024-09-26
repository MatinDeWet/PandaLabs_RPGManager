using Application.Common.Tools;

namespace Application.Features.CampaignFeatures.Commands.RefreshCampaignToken
{
    public class RefreshCampaignTokenHandler(ICampaignRepository repo, IUnitOfWork unitOfWork)
        : ICommandHandler<RefreshCampaignTokenRequest>
    {
        public async Task<Unit> Handle(RefreshCampaignTokenRequest request, CancellationToken cancellationToken)
        {
            var campaign = await repo.Campaigns
                .Where(c => c.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (campaign is null)
                throw new NotFoundException(nameof(Campaign), request.Id);

            campaign.Token = StringTools.GenerateSecureString(20);

            await repo.UpdateAsync(campaign, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
