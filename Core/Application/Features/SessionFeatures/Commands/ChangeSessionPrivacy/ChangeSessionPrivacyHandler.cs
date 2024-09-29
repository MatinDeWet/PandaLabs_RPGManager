namespace Application.Features.SessionFeatures.Commands.ChangeSessionPrivacy
{
    public class ChangeSessionPrivacyHandler(ISessionRepository repo, IUnitOfWork unitOfWork)
            : ICommandHandler<ChangeSessionPrivacyRequest>
    {
        public async Task<Unit> Handle(ChangeSessionPrivacyRequest request, CancellationToken cancellationToken)
        {
            var session = await repo.Sessions
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (session is null)
                throw new NotFoundException(nameof(Session), request.Id);

            session.IsPrivate = !session.IsPrivate;

            await repo.UpdateAsync(session, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
