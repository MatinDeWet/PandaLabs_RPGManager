using Domain.Common.Interfaces;

namespace Application.Features.NoteFeatures.Commands.UpdateNote
{
    public class UpdateNoteHandler(INoteRepository repo, IUnitOfWork unitOfWork)
        : ICommandHandler<UpdateNoteRequest>
    {
        public async Task<Unit> Handle(UpdateNoteRequest request, CancellationToken cancellationToken)
        {
            INoteLink? noteLink = await repo.GetNoteByLink(request.Id, request.NoteHolder, cancellationToken);

            if (noteLink is null)
                throw new NotFoundException(nameof(Note), request.Id);

            noteLink.Note.Title = request.Title;
            noteLink.Note.Content = request.Content;

            await repo.UpdateAsync(noteLink, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
