
using Domain.Common.Interfaces;

namespace Application.Features.NoteFeatures.Commands.ChangeNotePrivacy
{
    public class ChangeNotePrivacyHandler(INoteRepository repo, IUnitOfWork unitOfWork)
        : ICommandHandler<ChangeNotePrivacyRequest>
    {
        public async Task<Unit> Handle(ChangeNotePrivacyRequest request, CancellationToken cancellationToken)
        {
            INoteLink? noteLink = await repo.GetNoteByLink(request.Id, request.NoteHolder, cancellationToken);

            if (noteLink is null)
                throw new NotFoundException(nameof(Note), request.Id);

            noteLink.Note.IsPrivate = !noteLink.Note.IsPrivate;

            await repo.UpdateAsync(noteLink, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
