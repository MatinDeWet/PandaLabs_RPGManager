using Domain.Common.Interfaces;
using MediatR;

namespace Domain.Common.Events
{
    public class NoteHolderDeletedEvent : INotification
    {
        public INoteHolder NoteHolder { get; }

        public NoteHolderDeletedEvent(INoteHolder noteHolder)
        {
            NoteHolder = noteHolder;
        }
    }
}
