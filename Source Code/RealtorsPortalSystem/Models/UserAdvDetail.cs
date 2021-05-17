namespace RealtorsPortalSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserAdvDetail
    {
        [Key]
        public int OrderId { get; set; }

        public int? AdvId { get; set; }

        [StringLength(300)]
        public string AdvTitle { get; set; }

        public int? UserId { get; set; }

        public int? SeLLId { get; set; }

        [StringLength(20)]
        public string SeLLAccount { get; set; }

        public int? AgentId { get; set; }

        [StringLength(20)]
        public string AgentAccount { get; set; }

      
        public double? SubTotal { get; set; }

        public DateTime? DateUp { get; set; }
        public DateTime? ExpDate { get; set; }
        public double Onemonth { get; set; }
        public double Threemonths { get; set; }

        public double Sixmonths { get; set; }
    }
}
