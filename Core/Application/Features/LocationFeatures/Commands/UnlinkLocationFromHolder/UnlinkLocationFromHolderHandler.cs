using Domain.Common.Interfaces;

namespace Application.Features.LocationFeatures.Commands.UnlinkLocationFromHolder
{
    public class UnlinkLocationFromHolderHandler(ILocationRepository repo, IUnitOfWork unitOfWork)
            : ICommandHandler<UnlinkLocationFromHolderRequest>
    {
        public async Task<Unit> Handle(UnlinkLocationFromHolderRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ILocationLinkEntity?> query = request.LocationHolder switch
            {
                LocationHolderEnum.Session => repo.QueryLocationLink<SessionLocation>(
                    sl => sl.SessionId == request.LocationHolderId && sl.LocationId == request.LocationId),

                _ => throw new ArgumentOutOfRangeException(nameof(request.LocationHolder), request.LocationHolder, "Invalid location holder type.")
            };

            var locationLink = await query.FirstOrDefaultAsync(cancellationToken);

            if (locationLink is null)
                throw new NotFoundException(nameof(Location), new { request.LocationHolderId, request.LocationId });

            await repo.DeleteAsync(locationLink, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
