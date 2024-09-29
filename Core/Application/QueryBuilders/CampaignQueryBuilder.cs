using Application.Features.CampaignFeatures.Queries.SearchCampaigns;
using LinqKit;
using Pagination;
using Pagination.Enums;
using System.Linq.Expressions;

namespace Application.QueryBuilders
{
    internal static class CampaignQueryBuilder
    {
        internal static IQueryable<Campaign> ApplyFilters(this IQueryable<Campaign> query, SearchCampaignsRequest request, int userId)
        {
            var filterPredicate = BuildFilterExpression(request, userId);
            var searchPredicate = BuildSearchExpression(request.GetSearchTerms());
            return query
                .AsExpandable()
                .Where(searchPredicate)
                .Where(filterPredicate);
        }

        internal static Expression<Func<Campaign, bool>> BuildFilterExpression(SearchCampaignsRequest request, int userId)
        {
            var predicate = PredicateBuilder.New<Campaign>(true);

            if (request.Role.HasValue)
                predicate = predicate.And(o => o.Users.Any(x => x.Role == request.Role && x.UserId == userId));

            if (request.DateTimeCreatedRange is not null)
            {
                if (request.DateTimeCreatedRange.StartDateTime.HasValue)
                    predicate = predicate.And(o => o.DateTimeCreated >= request.DateTimeCreatedRange.StartDateTime);

                if (request.DateTimeCreatedRange.EndDateTime.HasValue)
                    predicate = predicate.And(o => o.DateTimeCreated <= request.DateTimeCreatedRange.EndDateTime);
            }

            return predicate;
        }

        internal static Expression<Func<Campaign, bool>> BuildSearchExpression(IEnumerable<string> terms, ExpressionMatchTypeEnum matchType = ExpressionMatchTypeEnum.StartsWith)
        {
            var predicate = PredicateBuilder.New<Campaign>(true);

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
