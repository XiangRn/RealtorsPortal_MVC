namespace RealtorsPortalSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PrivateSeller")]
    public partial class PrivateSeller
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PrivateSeller()
        {
            Advertisements = new HashSet<Advertisement>();
            Feedbacks = new HashSet<Feedback>();
        }

        [Key]
        public int SeLLId { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Required field")]
        public string SeLLAcount { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        public string SellPassword { get; set; }

        [StringLength(50)]
        public string SellFullname { get; set; }
        [Required(ErrorMessage = "Required field")]
        public bool? SellGender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SellDob { get; set; }

        //[RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 3 characters required")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100/*, MinimumLength = 3*//*, ErrorMessage = "Invalid"*/)]
        [DataType(DataType.MultilineText)]
        public string SellAddress { get; set; }

        [StringLength(20)]
        public string SellPhone { get; set; }

        [StringLength(30)]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string SellEmail { get; set; }

        public bool? SellActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Advertisement> Advertisements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
