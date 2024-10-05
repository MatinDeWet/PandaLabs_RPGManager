using Domain.Common.Events;

namespace Application.Features.NoteFeatures.Events
{
    public class NoteHolderDeletedEventHandler(INoteRepository repo)
        : INotificationHandler<NoteHolderDeletedEvent>
    {
        public async Task Handle(NoteHolderDeletedEvent notification, CancellationToken cancellationToken)
        {
            var notes = await repo.QueryNoteLink(notification.NoteHolder.GetType(), notification.NoteHolder.Id)
                .Select(nl => nl.Note)
                .ToListAsync(cancellationToken);

            await repo.DeleteAsync(notes, cancellationToken);
        }
    }
}
