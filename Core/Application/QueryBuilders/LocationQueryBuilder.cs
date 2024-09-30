using Application.Features.LocationFeatures.Queries.SearchLocations;
using LinqKit;
using Pagination;
using Pagination.Enums;
using System.Linq.Expressions;

namespace Application.QueryBuilders
{
    internal static class LocationQueryBuilder
    {
        internal static IQueryable<T> ApplyFilters<T>(
                this IQueryable<T> query,
                SearchLocationsRequest request,
                Expression<Func<T, Location>> locationSelector)
        {
            var filterPredicate = BuildFilterExpression(request, locationSelector);
            var searchPredicate = BuildSearchExpression(request.GetSearchTerms(), locationSelector);

            return query
                .AsExpandable()
                .Where(filterPredicate)
                .Where(searchPredicate);
        }

        internal static Expression<Func<T, bool>> BuildFilterExpression<T>(
                SearchLocationsRequest request,
                Expression<Func<T, Location>> locationSelector)
        {
            var predicate = PredicateBuilder.New<T>(true);

            if (request.CampaignId.HasValue)
                predicate = predicate.And(BuildLocationPropertyEquals(locationSelector, l => l.CampaignId, request.CampaignId.Value));

            if (request.ParentId.HasValue)
                predicate = predicate.And(BuildLocationPropertyEquals(locationSelector, l => l.ParentId, request.ParentId.Value));

            if (request.Type.HasValue)
                predicate = predicate.And(BuildLocationPropertyEquals(locationSelector, l => l.Type, request.Type.Value));

            if (request.SubTypeId.HasValue)
                predicate = predicate.And(BuildLocationPropertyEquals(locationSelector, l => l.SubTypeId, request.SubTypeId.Value));

            return predicate;
        }

        internal static Expression<Func<T, bool>> BuildSearchExpression<T>(
                IEnumerable<string> terms,
                Expression<Func<T, Location>> locationSelector,
                ExpressionMatchTypeEnum matchType = ExpressionMatchTypeEnum.StartsWith)
        {
            var predicate = PredicateBuilder.New<T>(true);

            var patternFormat = PageableExtensions.GetSearchPatternFormat(matchType);

            foreach (var term in terms)
            {
                var pattern = term.BuildSearchPattern(patternFormat);

                predicate = predicate.And(BuildLocationILike(locationSelector, l => l.Title, pattern));
            }

            return predicate;
        }

        private static Expression<Func<T, bool>> BuildLocationPropertyEquals<T, TProperty>(
        Expression<Func<T, Location>> locationSelector,
        Expression<Func<Location, TProperty>> propertySelector,
        TProperty value)
        {
            var parameter = locationSelector.Parameters[0];

            var locationAccess = Expression.Invoke(locationSelector, parameter);
            var propertyAccess = Expression.Invoke(propertySelector, locationAccess);

            var valueExpression = Expression.Constant(value, typeof(TProperty));

            var equalsExpression = Expression.Equal(propertyAccess, valueExpression);

            return Expression.Lambda<Func<T, bool>>(equalsExpression, parameter);
        }

        private static Expression<Func<T, bool>> BuildLocationILike<T>(
            Expression<Func<T, Location>> locationSelector,
            Expression<Func<Location, string>> propertySelector,
            string pattern)
        {
            var parameter = locationSelector.Parameters[0];

            var locationAccess = Expression.Invoke(locationSelector, parameter);

            var propertyAccess = Expression.Invoke(propertySelector, locationAccess);

            var patternExpression = Expression.Constant(pattern);

            var efFunctions = Expression.Property(null, typeof(EF), nameof(EF.Functions));

            var ilikeMethod = typeof(NpgsqlDbFunctionsExtensions).GetMethod(
                nameof(NpgsqlDbFunctionsExtensions.ILike),
                new[] { typeof(DbFunctions), typeof(string), typeof(string) });

            if (ilikeMethod == null)
                throw new InvalidOperationException("Could not find ILike method on NpgsqlDbFunctionsExtensions.");

            var ilikeCall = Expression.Call(
                ilikeMethod,
                efFunctions,
                propertyAccess,
                patternExpression);

            return Expression.Lambda<Func<T, bool>>(ilikeCall, parameter);
        }
    }
}
