namespace Application.Features.LocationFeatures.Commands.UpdateLocationSubType
{
    public class UpdateLocationSubTypeHandler(ILocationRepository locationRepo, ILocationSubTypeRepository subTypeRepo, IUnitOfWork unitOfWork)
            : ICommandHandler<UpdateLocationSubTypeRequest>
    {
        public async Task<Unit> Handle(UpdateLocationSubTypeRequest request, CancellationToken cancellationToken)
        {
            var location = await locationRepo.Locations
                .Where(l => l.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (location is null)
                throw new NotFoundException(nameof(Location), request.Id);

            if (request.SubTypeId is not null)
            {
                var subType = await subTypeRepo.LocationSubTypes
                 .Where(l => l.Id == request.SubTypeId)
                 .FirstOrDefaultAsync(cancellationToken);

                if (subType is null)
                    throw new NotFoundException(nameof(LocationSubType), request.SubTypeId);

                location.SubTypeId = request.SubTypeId;
            }
            else
            {
                location.SubTypeId = null;
            }

            await locationRepo.UpdateAsync(location, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
