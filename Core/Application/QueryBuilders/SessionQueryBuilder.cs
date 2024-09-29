using Application.Features.SessionFeatures.Queries.SearchSessions;
using LinqKit;
using Pagination;
using Pagination.Enums;
using System.Linq.Expressions;

namespace Application.QueryBuilders
{
    internal static class SessionQueryBuilder
    {
        internal static IQueryable<Session> ApplyFilters(this IQueryable<Session> query, SearchSessionsRequest request)
        {
            var filterPredicate = BuildFilterExpression(request);
            var searchPredicate = BuildSearchExpression(request.GetSearchTerms());
            return query
                .AsExpandable()
                .Where(searchPredicate)
                .Where(filterPredicate);
        }

        internal static Expression<Func<Session, bool>> BuildFilterExpression(SearchSessionsRequest request)
        {
            var predicate = PredicateBuilder.New<Session>(true);

            if (request.CampaignId.HasValue)
                predicate = predicate.And(o => o.CampaignId == request.CampaignId);

            if (request.IsPrivate.HasValue)
                predicate = predicate.And(o => o.IsPrivate == request.IsPrivate);

            if (request.ScheduledDateRange is not null)
            {
                if (request.ScheduledDateRange.StartDate.HasValue)
                    predicate = predicate.And(o => o.ScheduledDate >= request.ScheduledDateRange.StartDate);

                if (request.ScheduledDateRange.EndDate.HasValue)
                    predicate = predicate.And(o => o.ScheduledDate <= request.ScheduledDateRange.EndDate);
            }

            if (request.DateTimeCreatedRange is not null)
            {
                if (request.DateTimeCreatedRange.StartDateTime.HasValue)
                    predicate = predicate.And(o => o.DateTimeCreated >= request.DateTimeCreatedRange.StartDateTime);

                if (request.DateTimeCreatedRange.EndDateTime.HasValue)
                    predicate = predicate.And(o => o.DateTimeCreated <= request.DateTimeCreatedRange.EndDateTime);
            }

            return predicate;
        }

        internal static Expression<Func<Session, bool>> BuildSearchExpression(IEnumerable<string> terms, ExpressionMatchTypeEnum matchType = ExpressionMatchTypeEnum.StartsWith)
        {
            var predicate = PredicateBuilder.New<Session>(true);
            var patternFormat = PageableExtensions.GetSearchPatternFormat(matchType);
            foreach (var term in terms)
            {
                var pattern = term.BuildSearchPattern(patternFormat);

                predicate = predicate.And(o =>
                    EF.Functions.ILike(o.Title, pattern)
                );
            }
            return predicate;
        }
    }
}
