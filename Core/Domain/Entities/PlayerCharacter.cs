namespace Domain.Entities
{
    public class PlayerCharacter : Character
    {
        public Guid? CampaignId { get; set; }
        public virtual Campaign? Campaign { get; set; }
    }
}
