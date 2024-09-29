using Domain.Common.Interfaces;

namespace Application.Features.LocationFeatures.Commands.LinkLocationToHolder
{
    public class LinkLocationToHolderHandler(ILocationRepository repo, IUnitOfWork unitOfWork)
            : ICommandHandler<LinkLocationToHolderRequest>
    {
        public async Task<Unit> Handle(LinkLocationToHolderRequest request, CancellationToken cancellationToken)
        {
            ILocationLink locationLink = request.LocationHolder switch
            {
                LocationHolderEnum.Session => new SessionLocation(request.LocationHolderId, request.LocationId),

                _ => throw new ArgumentOutOfRangeException(nameof(request.LocationHolder), request.LocationHolder, "Invalid location holder type.")
            };

            await repo.InsertAsync(locationLink, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
