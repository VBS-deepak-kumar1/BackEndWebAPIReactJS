using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BackEndWebAPIReactJS.Models
{
    public partial class DeepSiteAddress
    {
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        [ForeignKey("CustId")]
        public int? CustId { get; set; }
        public virtual DeepakCustomer Cust { get; set; }
    }
}
