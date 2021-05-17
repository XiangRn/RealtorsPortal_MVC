namespace RealtorsPortalSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ward")]
    public partial class Ward
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Ward()
        //{
        //    Streets = new HashSet<Street>();
        //}

        public int WardId { get; set; }

        public int? CityId { get; set; }

        public int? DistrictId { get; set; }

        [StringLength(50)]
        public string WardName { get; set; }

        public virtual City City { get; set; }

        public virtual District District { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Street> Streets { get; set; }
    }
}
