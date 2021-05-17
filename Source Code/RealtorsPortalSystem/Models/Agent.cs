namespace RealtorsPortalSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Agent")]
    public partial class Agent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agent()
        {
            Advertisements = new HashSet<Advertisement>();
            Feedbacks = new HashSet<Feedback>();
        }

        public int AgentId { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Required field")]
        public string AgentAcount { get; set; }

        [StringLength(30)]
        public string AgentName { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        public string AgentPassword { get; set; }
        [Required(ErrorMessage = "Required field")]
        [StringLength(100)]
        [DataType(DataType.MultilineText)]
        public string AgentAddress { get; set; }
        [Required(ErrorMessage = "Required field")]
        [StringLength(20)]
        public string AgentPhone { get; set; }

        [StringLength(30)]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string AgentEmail { get; set; }

        [StringLength(30)]
        public string TaxCode { get; set; }

        [StringLength(200)]
        public string AgentAvatar { get; set; }

        public bool? AgentActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Advertisement> Advertisements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
