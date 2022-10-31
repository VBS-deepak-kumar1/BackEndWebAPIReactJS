using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BackEndWebAPIReactJS.Models
{
    public partial class DeepakLandlord
    {
        public int Landlord_Id { get; set; }
        public string Landlord_Name { get; set; }
        public string Landlord_Type { get; set; }
        public string Landlord_ContactInfo { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Jurisdiction { get; set; }
        [ForeignKey("Cust_Id")]
        public int? Cust_Id { get; set; }

        public virtual DeepakCustomer Cust { get; set; }
    }
}
