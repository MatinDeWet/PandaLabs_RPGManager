using Microsoft.EntityFrameworkCore;

namespace Application.Common.Behaviors.Interfaces
{
    public interface ITransactionBehavior
    {
        QueryTrackingBehavior QueryTrackingBehavior { get; set; }
    }
}
