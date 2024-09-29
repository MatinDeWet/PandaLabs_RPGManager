namespace Application.Features.CampaignFeatures.Queries.GetCampaignById
{
    public record GetCampaignByIdRequest(Guid Id) : IQuery<GetCampaignByIdResponse>;
}
