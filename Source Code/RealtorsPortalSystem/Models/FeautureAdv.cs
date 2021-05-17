namespace RealtorsPortalSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeautureAdv")]
    public partial class FeautureAdv
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FeaAdvId { get; set; }

        [StringLength(50)]
        public string Content { get; set; }

        [StringLength(50)]
        public string Header { get; set; }
    }
}
