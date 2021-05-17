namespace RealtorsPortalSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LastedNew
    {
        [Key]
        public int NewsId { get; set; }

        public int? AdvId { get; set; }

        public virtual Advertisement Advertisement { get; set; }
    }
}