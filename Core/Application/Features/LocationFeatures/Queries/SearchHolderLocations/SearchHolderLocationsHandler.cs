using Domain.Common.Interfaces;
using LinqKit;
using Pagination;
using Pagination.Models;
using System.Linq.Expressions;

namespace Application.Features.LocationFeatures.Queries.SearchHolderLocations
{
    public class SearchHolderLocationsHandler(ILocationRepository repo)
            : IQueryHandler<SearchHolderLocationsRequest, PageableResponse<SearchHolderLocationsResponse>>
    {
        public Task<PageableResponse<SearchHolderLocationsResponse>> Handle(SearchHolderLocationsRequest request, CancellationToken cancellationToken)
        {
            IQueryable<SearchHolderLocationsResponse> query = request.LocationHolder switch
            {
                LocationHolderEnum.Session => BuildSearchLocationQuery<SessionLocation>(
                    x => x.SessionId,
                    x => x.Session.Title,
                    request
                ),

                _ => throw new ArgumentOutOfRangeException(nameof(request.LocationHolder), request.LocationHolder, "Unsupported LocationHolder type.")
            };

            return query.ToPageableListAsync(request, cancellationToken);
        }

        private IQueryable<SearchHolderLocationsResponse> BuildSearchLocationQuery<TLocationLink>(
            Expression<Func<TLocationLink, Guid>> locationHolderIdSelector,
            Expression<Func<TLocationLink, string>> locationHolderNameSelector,
            SearchHolderLocationsRequest request)
            where TLocationLink : class, ILocationLink
        {
            var query = repo.QueryLocationLink<TLocationLink>();

            if (request.LocationHolderId.HasValue)
            {
                var predicate = GetHolderPredicate(locationHolderIdSelector, request.LocationHolderId.Value);
                query = query.Where(predicate);
            }

            return query.Select(locationLink => new SearchHolderLocationsResponse
            {
                Id = locationLink.Location.Id,
                CampaignId = locationLink.Location.CampaignId,
                CampaignName = locationLink.Location.Campaign.Title,
                ParentId = locationLink.Location.ParentId,
                ParentName = locationLink.Location.Parent!.Title ?? null!,
                Title = locationLink.Location.Title,
                Type = locationLink.Location.Type,
                SubTypeId = locationLink.Location.SubTypeId,
                SubTypeName = locationLink.Location.SubType!.Name ?? null!,
                IsPrivate = locationLink.Location.IsPrivate,
                DateTimeCreated = locationLink.Location.DateTimeCreated,
                LocaitonHolder = request.LocationHolder,
                NoteHolderId = locationHolderIdSelector.Invoke(locationLink),
                NoteHolderName = locationHolderNameSelector.Invoke(locationLink)
            });
        }

        private Expression<Func<TLocationLink, bool>> GetHolderPredicate<TLocationLink>(
            Expression<Func<TLocationLink, Guid>> locationHolderIdSelector,
            Guid LocationHolderId)
            where TLocationLink : class, ILocationLink
        {
            var parameter = locationHolderIdSelector.Parameters[0];
            var body = Expression.Equal(locationHolderIdSelector.Body, Expression.Constant(LocationHolderId));
            return Expression.Lambda<Func<TLocationLink, bool>>(body, parameter);
        }
    }
}
