namespace RealtorsPortalSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Advertisement")]
    public partial class Advertisement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Advertisement()
        {
            PhotoDetails = new HashSet<PhotoDetail>();
            LastedNews = new HashSet<LastedNew>();
        }

        [Key]
        public int AdvId { get; set; }

        public int? UserId { get; set; }

        public int? SeLLId { get; set; }

        public int? ModeId { get; set; }
      
        public int? CateId { get; set; }
        [Required(ErrorMessage = "Required field")]
        [StringLength(300)]
        public string Header { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Required field")]
        [StringLength(3000)]
        public string Content { get; set; }
        [Required(ErrorMessage = "Required field")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Required field")]
        [StringLength(50)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
       
        [StringLength(50)]
        public string Street { get; set; }
        
        [StringLength(50)]
        public string District { get; set; }
   
        [StringLength(50)]
        public string Ward { get; set; }
       
        [StringLength(50)]
        public string CityProvince { get; set; }
        [Required(ErrorMessage = "Required field")]
        public double Area { get; set; }
        //[Required(ErrorMessage = "Required field")]
        [StringLength(300)]
        public string Photothumbnail { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateUp { get; set; }
        //{
        //    get
        //    {
        //        return DateTime.Now;
        //    }
        //}

        [Column(TypeName = "date")]
        public DateTime? ExpDate { get; set; }

        public int? AgentId { get; set; }

        [StringLength(20)]
        public string AgentAcount { get; set; }

        [StringLength(20)]
        public string SellAcount { get; set; }
        public bool Approved { get; set; }

        public bool Paid { get; set; }
        [Required(ErrorMessage = "Required field")]
        public int Bedroom { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhotoDetail> PhotoDetails { get; set; }

        public virtual Agent Agent { get; set; }

        public virtual Category Category { get; set; }

        public virtual Mode Mode { get; set; }

        public virtual PrivateSeller PrivateSeller { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LastedNew> LastedNews { get; set; }
    }
}
