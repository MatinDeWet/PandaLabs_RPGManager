using Application.Features.NoteFeatures.Queries.SearchNotes;
using Domain.Common.Interfaces;
using LinqKit;
using Pagination;
using Pagination.Enums;
using System.Linq.Expressions;

namespace Application.QueryBuilders
{
    internal static class NoteQueryBuilder
    {
        internal static IQueryable<INoteLink> ApplyFilters(
                this IQueryable<INoteLink> query,
                SearchNotesRequest request)
        {
            var filterPredicate = BuildFilterExpression(request);
            var searchPredicate = BuildSearchExpression(request.GetSearchTerms());
            return query
                .AsExpandable()
                .Where(filterPredicate)
                .Where(searchPredicate);
        }

        internal static Expression<Func<INoteLink, bool>> BuildFilterExpression(
            SearchNotesRequest request)
        {
            var predicate = PredicateBuilder.New<INoteLink>(true);

            if (request.IsPrivate.HasValue)
                predicate = predicate.And(o => o.Note.IsPrivate == request.IsPrivate);

            if (request.CreatedById.HasValue)
                predicate = predicate.And(o => o.Note.CreatedById == request.CreatedById);

            if (request.DateTimeCreatedRange is not null)
            {
                if (request.DateTimeCreatedRange.StartDateTime.HasValue)
                    predicate = predicate.And(o => o.Note.DateTimeCreated >= request.DateTimeCreatedRange.StartDateTime);

                if (request.DateTimeCreatedRange.EndDateTime.HasValue)
                    predicate = predicate.And(o => o.Note.DateTimeCreated <= request.DateTimeCreatedRange.EndDateTime);
            }

            return predicate;
        }

        internal static Expression<Func<INoteLink, bool>> BuildSearchExpression(
            IEnumerable<string> terms,
            ExpressionMatchTypeEnum matchType = ExpressionMatchTypeEnum.StartsWith)
        {
            var predicate = PredicateBuilder.New<INoteLink>(true);

            var patternFormat = PageableExtensions.GetSearchPatternFormat(matchType);

            foreach (var term in terms)
            {
                var pattern = term.BuildSearchPattern(patternFormat);

                predicate = predicate.And(o =>
                    EF.Functions.ILike(o.Note.Title, pattern)
                );
            }
            return predicate;
        }
    }
}
