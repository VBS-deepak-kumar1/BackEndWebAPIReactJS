using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BackEndWebAPIReactJS.Models
{
    public partial class DeepakSite
    {
        public int? Site_Id { get; set; }
        public string Site_Name { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public string Project_Manager { get; set; }
        public string RealEstate_Specialist { get; set; }
        public string Field_Coordinator { get; set; }
        public string SiteAcq_Vendor { get; set; }
        public string Civil_Vendor { get; set; }
        public string Construction_Vendor { get; set; }
        public string Ae_Firm { get; set; }
        [ForeignKey("Cust_Id")]
        public int? Cust_Id { get; set; }

        public virtual DeepakCustomer Cust { get; set; }
    }
}
