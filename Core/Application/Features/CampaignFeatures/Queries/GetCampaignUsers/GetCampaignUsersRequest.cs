namespace Application.Features.CampaignFeatures.Queries.GetCampaignUsers
{
    public record GetCampaignUsersRequest(Guid Id) : IQuery<List<GetCampaignUsersResponse>>;
}
