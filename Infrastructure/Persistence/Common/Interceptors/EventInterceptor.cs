using Domain.Common.Events;
using Domain.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Persistence.Common.Interceptors
{
    public class EventInterceptor(IMediator mediator) : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            DispatchDeleteEvent(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            await DispatchDeleteEvent(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private async Task DispatchDeleteEvent(DbContext? context)
        {
            if (context is null)
                return;

            var entries = context.ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Deleted && e.Entity is IHolder)
                .ToList();

            if (!entries.Any())
                return;

            await DispatchNoteHolderDeletedEvent(entries);
        }

        private async Task DispatchNoteHolderDeletedEvent(List<EntityEntry> entityEntries)
        {
            var deletedHolders = entityEntries
                .Where(e => e.Entity is INoteHolder)
                .Select(e => e.Entity as INoteHolder)
                .Distinct()
                .ToList();

            if (!deletedHolders.Any())
                return;

            var events = deletedHolders.Select(h => new NoteHolderDeletedEvent(h!));

            foreach (var @event in events)
                await mediator.Publish(@event);
        }
    }
}
