using Application.Features.LocationFeatures.Queries.SearchHolderLocations;
using Application.Features.LocationFeatures.Queries.SearchLocations;
using Application.Features.NoteFeatures.Queries.SearchNotes;
using Domain.Common.Interfaces;
using LinqKit;
using Pagination;
using Pagination.Enums;
using System.Linq;
using System.Linq.Expressions;

namespace Application.QueryBuilders
{
    internal static class LocationQueryBuilder
    {
        internal static IQueryable<Location> ApplyFilters(this IQueryable<Location> query, SearchLocationsRequest request)
        {
            var filterPredicate = BuildFilterExpression(request);
            var searchPredicate = BuildSearchExpression(request.GetSearchTerms());
            return query
                .AsExpandable()
                .Where(searchPredicate)
                .Where(filterPredicate);
        }

        internal static Expression<Func<Location, bool>> BuildFilterExpression(SearchLocationsRequest request)
        {
            var predicate = PredicateBuilder.New<Location>(true);

            if (request.CampaignId.HasValue)
                predicate = predicate.And(o => o.CampaignId == request.CampaignId);

            if (request.ParentId.HasValue)
                predicate = predicate.And(o => o.ParentId == request.ParentId);

            if (request.Type.HasValue)
                predicate = predicate.And(o => o.Type == request.Type);

            if (request.SubTypeId.HasValue)
                predicate = predicate.And(o => o.SubTypeId == request.SubTypeId);

            return predicate;
        }

        internal static Expression<Func<Location, bool>> BuildSearchExpression(IEnumerable<string> terms, ExpressionMatchTypeEnum matchType = ExpressionMatchTypeEnum.StartsWith)
        {
            var predicate = PredicateBuilder.New<Location>(true);

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
