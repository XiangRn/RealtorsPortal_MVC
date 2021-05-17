namespace RealtorsPortalSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Feedback
    {
        public int FeedbackId { get; set; }

        public int? ModeId { get; set; }

        public int? AgentId { get; set; }

        public int? SeLLId { get; set; }

        [StringLength(1000)]
        public string FeedbackContent { get; set; }

        [StringLength(1000)]
        public string FeedbackReply { get; set; }

        public virtual Agent Agent { get; set; }

        public virtual Mode Mode { get; set; }

        public virtual PrivateSeller PrivateSeller { get; set; }
    }
}