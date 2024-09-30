using Application.Features.LocationFeatures.Queries.SearchHolderLocations;
using Application.Features.LocationFeatures.Queries.SearchLocations;
using Domain.Common.Interfaces;
using LinqKit;
using Pagination;
using Pagination.Enums;
using System.Linq.Expressions;

namespace Application.QueryBuilders
{
    internal static class LocationLinkQueryBuilder
    {
        internal static IQueryable<ILocationLink> ApplyFilters(this IQueryable<ILocationLink> query, SearchHolderLocationsRequest request)
        {
            var filterPredicate = BuildFilterExpression(request);
            var searchPredicate = BuildSearchExpression(request.GetSearchTerms());
            return query
                .AsExpandable()
                .Where(filterPredicate)
                .Where(searchPredicate);
        }

        internal static Expression<Func<ILocationLink, bool>> BuildFilterExpression(SearchLocationsRequest request)
        {
            var predicate = PredicateBuilder.New<ILocationLink>(true);

            if (request.CampaignId.HasValue)
                predicate = predicate.And(o => o.Location.CampaignId == request.CampaignId);

            if (request.ParentId.HasValue)
                predicate = predicate.And(o => o.Location.ParentId == request.ParentId);

            if (request.Type.HasValue)
                predicate = predicate.And(o => o.Location.Type == request.Type);

            if (request.SubTypeId.HasValue)
                predicate = predicate.And(o => o.Location.SubTypeId == request.SubTypeId);

            return predicate;
        }

        internal static Expression<Func<ILocationLink, bool>> BuildSearchExpression(IEnumerable<string> terms, ExpressionMatchTypeEnum matchType = ExpressionMatchTypeEnum.StartsWith)
        {
            var predicate = PredicateBuilder.New<ILocationLink>(true);

            var patternFormat = PageableExtensions.GetSearchPatternFormat(matchType);

            foreach (var term in terms)
            {
                var pattern = term.BuildSearchPattern(patternFormat);

                predicate = predicate.And(o =>
                    EF.Functions.ILike(o.Location.Title, pattern)
                );
            }
            return predicate;
        }
    }
}
