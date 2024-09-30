
using Domain.Common.Interfaces;

namespace Application.Features.NoteFeatures.Commands.DeleteNote
{
    public class DeleteNoteHandler(INoteRepository repo, IUnitOfWork unitOfWork)
        : ICommandHandler<DeleteNoteRequest>
    {
        public async Task<Unit> Handle(DeleteNoteRequest request, CancellationToken cancellationToken)
        {
            INoteLink? noteLink = await repo.GetNoteByLink(request.Id, request.NoteHolder, cancellationToken);

            if (noteLink is null)
                throw new NotFoundException(nameof(Note), request.Id);

            await repo.DeleteAsync(noteLink, cancellationToken);
            await repo.DeleteAsync(noteLink.Note, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
