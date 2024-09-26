namespace Application.Features.SessionFeatures.Commands.CreateSession
{
    public class CreateSessionHandler(ISessionRepository repo, IUnitOfWork unitOfWork)
            : ICommandHandler<CreateSessionRequest, CreateSessionResponse>
    {
        public async Task<CreateSessionResponse> Handle(CreateSessionRequest request, CancellationToken cancellationToken)
        {
            var session = new Session
            {
                CampaignId = request.CampaignId,
                Title = request.Title
            };

            await repo.InsertAsync(session, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return new CreateSessionResponse(session.Id);
        }
    }
}
