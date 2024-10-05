namespace Domain.Entities
{
    public class NonPlayerCharacter : Character
    {
        public Guid CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; } = null!;

        public bool IsPrivate { get; set; } = true;
    }
}
