namespace Application.Features.LocationFeatures.Commands.UnlinkLocationFromHolder
{
    public class UnlinkLocationFromHolderHandler(ILocationRepository repo, IUnitOfWork unitOfWork)
            : ICommandHandler<UnlinkLocationFromHolderRequest>
    {
        public async Task<Unit> Handle(UnlinkLocationFromHolderRequest request, CancellationToken cancellationToken)
        {
            var locationLink = await repo.QueryLocationLink(request.LocationHolder, request.LocationHolderId)
                .Where(x => x.LocationId == request.LocationId)
                .FirstOrDefaultAsync(cancellationToken);

            if (locationLink is null)
                throw new NotFoundException(nameof(Location), new { request.LocationHolderId, request.LocationId });

            await repo.DeleteAsync(locationLink, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
