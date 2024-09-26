namespace Application.Features.CampaignFeatures.Commands.UpdateCampaign
{
    public class UpdateCampaignRequest : ICommand
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }
    }
}
