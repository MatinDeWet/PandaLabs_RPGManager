namespace Application.Features.LocationFeatures.Commands.UpdateLocationParent
{
    public class UpdateLocationParentHandler(ILocationRepository repo, IUnitOfWork unitOfWork)
            : ICommandHandler<UpdateLocationParentRequest>
    {
        public async Task<Unit> Handle(UpdateLocationParentRequest request, CancellationToken cancellationToken)
        {
            var location = await repo.Locations
                .Where(l => l.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (location is null)
                throw new NotFoundException(nameof(Location), request.Id);

            if (request.ParentId is not null)
            {
                var parent = await repo.Locations
                    .Where(l => l.Id == request.ParentId)
                    .FirstOrDefaultAsync(cancellationToken);

                if (parent is null)
                    throw new NotFoundException(nameof(Location), request.ParentId);

                location.ParentId = request.ParentId;
            }
            else
            {
                location.ParentId = null;
            }

            await repo.UpdateAsync(location, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
