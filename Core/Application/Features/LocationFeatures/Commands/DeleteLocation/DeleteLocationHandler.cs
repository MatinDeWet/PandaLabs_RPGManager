namespace Application.Features.LocationFeatures.Commands.DeleteLocation
{
    public class DeleteLocationHandler(ILocationRepository repo, IUnitOfWork unitOfWork)
            : ICommandHandler<DeleteLocationRequest>
    {
        public async Task<Unit> Handle(DeleteLocationRequest request, CancellationToken cancellationToken)
        {
            var location = await repo.Locations
                .Where(l => l.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (location is null)
                throw new NotFoundException(nameof(Location), request.Id);

            await repo.DeleteAsync(location, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
