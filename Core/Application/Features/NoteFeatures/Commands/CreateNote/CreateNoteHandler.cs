using Domain.Common.Interfaces;

namespace Application.Features.NoteFeatures.Commands.CreateNote
{
    public class CreateNoteHandler(INoteRepository repo, IUnitOfWork unitOfWork)
        : ICommandHandler<CreateNoteRequest, CreateNoteResponse>
    {
        public async Task<CreateNoteResponse> Handle(CreateNoteRequest request, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                Title = request.Title,
                Content = request.Content
            };

            INoteLink noteLink = request.NoteHolder switch
            {
                NoteHolderEnum.Campaign => new CampaignNote(request.HolderId, note),
                NoteHolderEnum.Session => new SessionNote(request.HolderId, note),
                NoteHolderEnum.Location => new LocationNote(request.HolderId, note),
                _ => throw new NoteHolderOutOfRangeException(nameof(request.NoteHolder), request.NoteHolder)
            };

            await repo.InsertAsync(noteLink, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return new CreateNoteResponse(note.Id);
        }
    }
}
