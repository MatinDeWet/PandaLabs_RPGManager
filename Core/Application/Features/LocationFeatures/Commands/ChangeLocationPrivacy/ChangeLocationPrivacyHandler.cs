namespace Application.Features.LocationFeatures.Commands.ChangeLocationPrivacy
{
    public class ChangeLocationPrivacyHandler(ILocationRepository repo, IUnitOfWork unitOfWork)
            : ICommandHandler<ChangeLocationPrivacyRequest>
    {
        public async Task<Unit> Handle(ChangeLocationPrivacyRequest request, CancellationToken cancellationToken)
        {
            var location = await repo.Locations
                .Where(l => l.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (location is null)
                throw new NotFoundException(nameof(Location), request.Id);

            location.IsPrivate = !location.IsPrivate;

            await repo.UpdateAsync(location, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
