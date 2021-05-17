namespace RealtorsPortalSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bank")]
    public partial class Bank
    {
        public int BankId { get; set; }

        [StringLength(30)]
        public string BankName { get; set; }

        public double? BankRate { get; set; }
    }
}