﻿using Domain.Common.BaseEntities;
using Domain.Common.Interfaces;

namespace Domain.Entities
{
    public class Session : PrivatibleEntity<Guid>, INoteHolder
    {
        public Guid CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string? Summary { get; set; }

        public string? HouseKeeping { get; set; }

        public DateOnly? ScheduledDate { get; set; }

        public virtual ICollection<SessionLocation> SessionLocations { get; set; } = new List<SessionLocation>();

        public virtual ICollection<SessionNote> Notes { get; set; } = new List<SessionNote>();
    }
}
