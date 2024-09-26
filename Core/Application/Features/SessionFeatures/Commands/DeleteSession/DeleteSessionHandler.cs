namespace Application.Features.SessionFeatures.Commands.DeleteSession
{
    public class DeleteSessionHandler(ISessionRepository repo, IUnitOfWork unitOfWork)
        : ICommandHandler<DeleteSessionRequest>
    {
        public async Task<Unit> Handle(DeleteSessionRequest request, CancellationToken cancellationToken)
        {
            var session = await repo.Sessions
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (session is null)
                throw new NotFoundException(nameof(Session), request.Id);

            await repo.DeleteAsync(session, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
