using Application.Common.Behaviors.Interfaces;

namespace Application.Common.Behaviors
{
    public class TrackingBehavior<TRequest, TResponse>
                    (ITransactionBehavior context)
                    : IPipelineBehavior<TRequest, TResponse>
                    where TRequest : IQuery<TResponse>
                    where TResponse : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var originalTrackingBehavior = context.QueryTrackingBehavior;

            try
            {
                context.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                return await next();
            }
            finally
            {
                context.QueryTrackingBehavior = originalTrackingBehavior;
            }
        }
    }
}
