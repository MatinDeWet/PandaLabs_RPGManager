namespace Application.Features.CampaignFeatures.Commands.UpdateCampaign
{
    public class UpdateCampaignHandler(ICampaignRepository repo, IUnitOfWork unitOfWork)
        : ICommandHandler<UpdateCampaignRequest>
    {
        public async Task<Unit> Handle(UpdateCampaignRequest request, CancellationToken cancellationToken)
        {
            var campaign = await repo.Campaigns
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (campaign is null)
                throw new NotFoundException(nameof(Campaign), request.Id);

            campaign.Title = request.Title;
            campaign.Description = request.Description;

            await repo.UpdateAsync(campaign, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
