namespace RealtorsPortalSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhotoDetail")]
    public partial class PhotoDetail
    {
        [Key]
        public int IdImage { get; set; }

        public int AdvId { get; set; }

        [StringLength(200)]
        public string Image { get; set; }
        public Guid Guidimage { get; set; }

        [StringLength(200)]
        public string Extension { get; set; }

        public virtual Advertisement Advertisement { get; set; }
    }
}
