using Domain.Common.Abstractions;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Persistence.Common.Interceptors
{
    public class AuditableEntityInterceptor : SaveChangesInterceptor
    {
        private readonly IIdentityInfo _identityInfo;

        public AuditableEntityInterceptor(IIdentityInfo identityInfo)
        {
            _identityInfo = identityInfo;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateEntities(DbContext? context)
        {
            if (context is null) return;

            foreach (var entry in context.ChangeTracker.Entries<IEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity.CreatedById == 0)
                        entry.Entity.CreatedById = _identityInfo.GetIdentityId();

                    entry.Entity.DateTimeCreated = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
                {
                }
            }
        }
    }
}
