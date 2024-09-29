namespace Application.Features.LocationFeatures.Commands.CreateLocation
{
    public class CreateLocationHandler(ILocationRepository repo, IUnitOfWork unitOfWork)
            : ICommandHandler<CreateLocationRequest, CreateLocationResponse>
    {
        public async Task<CreateLocationResponse> Handle(CreateLocationRequest request, CancellationToken cancellationToken)
        {
            var location = new Location
            {
                CampaignId = request.CampaignId,
                Title = request.Title,
                Type = request.Type
            };

            await repo.InsertAsync(location, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return new CreateLocationResponse(location.Id);
        }
    }
}
