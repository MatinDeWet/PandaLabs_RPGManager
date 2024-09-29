namespace Application.Features.LocationFeatures.Commands.UpdateLocation
{
    public class UpdateLocationHandler(ILocationRepository repo, IUnitOfWork unitOfWork)
            : ICommandHandler<UpdateLocationRequest>
    {
        public async Task<Unit> Handle(UpdateLocationRequest request, CancellationToken cancellationToken)
        {
            var location = await repo.Locations
                .Where(l => l.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (location is null)
                throw new NotFoundException(nameof(Location), request.Id);

            location.Title = request.Title;
            location.Description = request.Description;

            await repo.UpdateAsync(location, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
