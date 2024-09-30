using System.Linq.Expressions;

namespace Persistence.Common
{
    public static class QueryExtensions
    {
        public static Expression<Func<T, bool>> Compose<T>(
        this Expression<Func<T, Guid>> selector, Expression<Func<Guid, bool>> predicate)
        {
            var parameter = selector.Parameters[0];
            var body = Expression.Invoke(predicate, selector.Body);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}
