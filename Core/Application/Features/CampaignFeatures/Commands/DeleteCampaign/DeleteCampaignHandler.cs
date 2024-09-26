namespace Application.Features.CampaignFeatures.Commands.DeleteCampaign
{
    public class DeleteCampaignHandler(ICampaignRepository repo, IUnitOfWork unitOfWork)
        : ICommandHandler<DeleteCampaignRequest>
    {
        public async Task<Unit> Handle(DeleteCampaignRequest request, CancellationToken cancellationToken)
        {
            var campaign = await repo.Campaigns
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (campaign is null)
                throw new NotFoundException(nameof(Campaign), request.Id);

            await repo.DeleteAsync(campaign, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
