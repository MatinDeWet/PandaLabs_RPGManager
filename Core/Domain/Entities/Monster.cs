namespace Domain.Entities
{
    public class Monster : Character
    {
        public SizeEnum Size { get; set; }

        public ChallengeRatingEnum ChallengeRating { get; set; }

        public MonsterTypeEnum MonsterType { get; set; }

        public Guid? CampaignId { get; set; }
        public virtual Campaign? Campaign { get; set; }

        public bool? IsPrivate { get; set; }
    }
}
