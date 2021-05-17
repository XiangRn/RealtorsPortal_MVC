namespace RealtorsPortalSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        [StringLength(30)]
        [Required(ErrorMessage = "Required field")]
        public string AdminAcount { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        public string AdminPass { get; set; }
    }
}
