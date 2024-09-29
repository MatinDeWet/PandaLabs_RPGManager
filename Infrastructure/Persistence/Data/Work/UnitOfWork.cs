using EntitySecurity.Contract.Repository;

namespace Persistence.Data.Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ManagerContext _ctx;

        public UnitOfWork(ManagerContext ctx)
        {
            _ctx = ctx;
        }

        public Task SaveAsync(CancellationToken cancellationToken)
        {
            return _ctx.SaveChangesAsync(cancellationToken);
        }
    }
}
