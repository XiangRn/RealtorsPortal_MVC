using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealtorsPortalSystem.Models
{
    public class SellerVsAgent
    {
        public int Id { get; set; }
        public PrivateSeller PrivateSeller { get; set; }
        public Agent Agent { get; set; }
    }
}