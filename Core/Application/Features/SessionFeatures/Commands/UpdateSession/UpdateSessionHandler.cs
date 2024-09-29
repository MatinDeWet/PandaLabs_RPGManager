namespace Application.Features.SessionFeatures.Commands.UpdateSession
{
    public class UpdateSessionHandler(ISessionRepository repo, IUnitOfWork unitOfWork)
            : ICommandHandler<UpdateSessionRequest>
    {
        public async Task<Unit> Handle(UpdateSessionRequest request, CancellationToken cancellationToken)
        {
            var session = await repo.Sessions
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (session is null)
                throw new NotFoundException(nameof(Session), request.Id);

            session.Title = request.Title;
            session.Summary = request.Summary;
            session.HouseKeeping = request.HouseKeeping;
            session.ScheduledDate = request.ScheduledDate;

            await repo.UpdateAsync(session, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
