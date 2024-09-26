using Application.Common.Behaviors.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data.Context
{
    public class ManagerContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>, ITransactionBehavior
    {
        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ManagerContext).Assembly);

            base.OnModelCreating(builder);
        }

        public QueryTrackingBehavior QueryTrackingBehavior
        {
            get => ChangeTracker.QueryTrackingBehavior;
            set => ChangeTracker.QueryTrackingBehavior = value;
        }
    }
}
