namespace RealtorsPortalSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Street")]
    public partial class Street
    {
        public int StreetId { get; set; }

        public int? CityId { get; set; }

        public int? DistrictId { get; set; }

        public int? WardId { get; set; }

        [StringLength(100)]
        public string StreetName { get; set; }

        public virtual City City { get; set; }

        public virtual District District { get; set; }

        public virtual Ward Ward { get; set; }
    }
}
