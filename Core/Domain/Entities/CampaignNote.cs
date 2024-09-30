using Domain.Common.Interfaces;

namespace Domain.Entities
{
    public class CampaignNote : INoteLink
    {
        public CampaignNote()
        {
        }

        public CampaignNote(Guid campaignId, Note note)
        {
            CampaignId = campaignId;
            Note = note;
        }

        public Guid CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; } = null!;

        public Guid NoteId { get; set; }
        public virtual Note Note { get; set; } = null!;
    }
}
